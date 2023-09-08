using Sat.Recruitment.Core.DTOs.Common;
using Sat.Recruitment.Core.Utils.Exceptions.Models;

namespace Sat.Recruitment.Core.Generics.DTOs.Response
{
    public static class BaseDtoResponseUtils
    {
        public static DtoError AppExcToError(AppException appException)
        {
            return new DtoError(appException);
        }
    }
}
