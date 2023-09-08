using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.DTOs.Response;

namespace Sat.Recruitment.Core.DTOs.Responses.User
{
    public class DtoGetUsersResponse : BaseDtoResponse
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
