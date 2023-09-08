using Microsoft.Extensions.Logging;
using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.Utils.Exceptions.Services
{
    public class ExceptionService : IExceptionService
    {
        private readonly ILogger<ExceptionService> _logger;

        public ExceptionService(ILogger<ExceptionService> logger)
        {
            _logger = logger;
        }

        public AppException Exception(string mensaje)
        {
            AppException appException = new()
            {
                TipoDeError = string.Empty,
                NumeroDeError = string.Empty,
                DescripcionDeError = string.Empty,
                MensajeDeError = mensaje
            };

            _logger.LogError(appException, appException.MensajeDeError);

            return appException;
        }

        public AppException Exception(Exception exception)
        {
            return DefaultException(exception.Message);
        }

        public AppException ParameterNotFound(string parameterName)
        {
            string mensaje = string.Format("No se encontró el parámetro {0}.", parameterName);
            
            AppException appException = new()
            {
                TipoDeError = string.Empty,
                NumeroDeError = string.Empty,
                DescripcionDeError = string.Empty,
                MensajeDeError = mensaje
            };

            _logger.LogError(appException, appException.MensajeDeError);

            return appException;
        }

        public AppException PropertyNotFound(string propertyName)
        {
            string mensaje = string.Format("No se encontró la propiedad {0} en el objeto evaluado.", propertyName);
            
            AppException appException = new()
            {
                TipoDeError = string.Empty,
                NumeroDeError = string.Empty,
                DescripcionDeError = string.Empty,
                MensajeDeError = mensaje
            };

            _logger.LogError(appException, appException.MensajeDeError);

            return appException;
        }

        #region private

        private AppException DefaultException(string mensaje)
        {
            AppException appException = new()
            {
                TipoDeError = string.Empty,
                NumeroDeError = string.Empty,
                DescripcionDeError = string.Empty,
                MensajeDeError = mensaje
            };

            _logger.LogError(appException, appException.MensajeDeError);

            return appException;
        }

        #endregion
    }
}
