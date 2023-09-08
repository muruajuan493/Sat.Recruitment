using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.DTOs.Common;
using Sat.Recruitment.Core.Generics.Services;
using Sat.Recruitment.Core.Interfaces.Generics.DTOs.Response;
using Sat.Recruitment.Core.Utils.Exceptions.Handlers;
using Sat.Recruitment.Core.Utils.Exceptions.Models;
using System.Net;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Core.Generics.DTOs.Response
{
    public abstract class BaseDtoResponse : IBaseDtoResponse
    {
        // Properties
        [JsonIgnore]
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public string EstadoRespuesta { get; set; } = "OK";

        public string TimeStamp { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<DtoError>? ERRORES { set; get; }

        // Functions
        public IBaseDtoResponse Completar()
        {
            TimeStamp = DateTime.Now.ToString("s");
            EstadoRespuesta = StatusCode switch
            {
                (int)HttpStatusCode.OK => "OK",
                (int)HttpStatusCode.BadRequest => "businessException",
                (int)HttpStatusCode.Unauthorized => "businessException",
                _ => "systemException",
            };

            return this;
        }

        // Validacion de errores para respuesta de servicio
        public void ValidarErrores(IBaseResult resultadoServicios)
        {
            if (resultadoServicios.TieneExcepciones)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
                GenerarListaDeErrores(resultadoServicios.Excepciones);
                throw new ResponseException();
            }
            if (!resultadoServicios.Exito)
            {
                StatusCode = StatusCodes.Status400BadRequest;
                GenerarListaDeErrores(resultadoServicios.Excepciones);
                throw new ResponseException();
            }
        }

        void GenerarListaDeErrores(List<AppException> exceptions)
        {
            ERRORES ??= new();

            if (exceptions != null)
            {
                ERRORES = exceptions.GetListDtoError();
            }
        }

        public void GenerarError(Exception exception)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
            ERRORES ??= new();
            ERRORES = new List<AppException>() { AppExceptionHandler.NewException(exception) }.GetListDtoError();
        }

        // Implementación IActionResult
        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var objectResult = new ObjectResult(this)
            {
                StatusCode = StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
