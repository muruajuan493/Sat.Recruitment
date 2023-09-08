using Sat.Recruitment.Core.Generics.DTOs.Request;

namespace Sat.Recruitment.Core.DTOs.Requests.User
{
    public class DtoCreateUserRequest : BaseDtoRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Money { get; set; } = string.Empty;
    }
}
