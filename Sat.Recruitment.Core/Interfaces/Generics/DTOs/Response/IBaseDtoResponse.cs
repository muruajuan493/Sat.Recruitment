using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.DTOs.Common;
using Sat.Recruitment.Core.Generics.Services;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Core.Interfaces.Generics.DTOs.Response
{
    public interface IBaseDtoResponse : IActionResult
    {
        // Properties
        [JsonIgnore]
        int StatusCode { get; set; }

        string EstadoRespuesta { get; set; }

        string TimeStamp { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        List<DtoError>? ERRORES { set; get; }

        // Functions
        IBaseDtoResponse Completar();

        // Validacion de errores para respuesta de servicio
        void ValidarErrores(IBaseResult resultadoServicios);

        void GenerarError(Exception exception);
    }
}
