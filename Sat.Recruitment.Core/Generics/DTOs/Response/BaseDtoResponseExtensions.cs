using Sat.Recruitment.Core.DTOs.Common;
using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.Generics.DTOs.Response
{
    public static class BaseDtoResponseExtensions
    {
        public static List<DtoError> GetListDtoError(this List<AppException> exceptions)
        {
            return exceptions.ConvertAll(new Converter<AppException, DtoError>(BaseDtoResponseUtils.AppExcToError));
        }
    }
}
