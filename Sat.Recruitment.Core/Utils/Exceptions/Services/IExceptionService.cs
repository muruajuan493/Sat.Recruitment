using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.Utils.Exceptions.Services
{
    public interface IExceptionService
    {
        AppException Exception(string mensaje);
        AppException Exception(Exception exception);
        AppException ParameterNotFound(string parameterName);
        AppException PropertyNotFound(string propertyName);
    }
}
