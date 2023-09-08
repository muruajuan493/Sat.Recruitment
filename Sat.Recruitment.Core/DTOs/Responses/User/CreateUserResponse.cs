using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.DTOs.Response;

namespace Sat.Recruitment.Core.DTOs.Responses.User
{
    public class DtoCreateUserResponse : BaseDtoResponse
    {
        public UserDto User { get; set; } = new();
    }
}
