using Sat.Recruitment.Core.Generics.Entities;

namespace Sat.Recruitment.Core.Entities.User
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public decimal Money { get; set; }

        public UserEntity(string name, string email, string address, string phone, string userType, string money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = decimal.Parse(money);
        }

        public UserEntity()
        {
        }
    }
}
