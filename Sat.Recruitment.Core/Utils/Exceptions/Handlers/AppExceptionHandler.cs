using Sat.Recruitment.Core.Utils.Exceptions.Models;
using Sat.Recruitment.Core.Utils.Exceptions.Services;
using static Sat.Recruitment.Core.PostInjection;

namespace Sat.Recruitment.Core.Utils.Exceptions.Handlers
{
    public static class AppExceptionHandler
    {
        private static readonly IExceptionService exceptionService = Injector.GetService<IExceptionService>();

        public static AppException NewException(string mensaje) => exceptionService.Exception(mensaje);

        public static AppException NewException(Exception exception) => exceptionService.Exception(exception);

        public static AppException NewParameterException(string parameterName) => exceptionService.ParameterNotFound(parameterName);

        public static AppException NewPropertyException(string propertyName) => exceptionService.PropertyNotFound(propertyName);
    }
}
