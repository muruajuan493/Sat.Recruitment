using Sat.Recruitment.Core.Entities.User;
using Sat.Recruitment.Core.Generics.Services;

namespace Sat.Recruitment.Core.BussinesServices.User.Contexto
{
    public class ContextCreateUser : BaseContext
    {
        public UserEntity User { get; set; }
    }
}
