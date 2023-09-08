using Sat.Recruitment.Core.Generics.DTOs.Entities;

namespace Sat.Recruitment.Core.DTOs.Entities
{
    public class UserDto : BaseDtoEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public decimal Money { get; set; }

        public UserDto(int id, string name, string email, string address, string phone, string userType, string money)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = decimal.Parse(money);
        }

        public UserDto()
        {
        }
    }
}
