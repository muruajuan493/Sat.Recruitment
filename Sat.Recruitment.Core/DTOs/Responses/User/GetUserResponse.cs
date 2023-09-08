using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.DTOs.Response;

namespace Sat.Recruitment.Core.DTOs.Responses.User
{
    public class DtoGetUserResponse : BaseDtoResponse
    {
        public UserDto User { get; set; } = new();
    }
}
