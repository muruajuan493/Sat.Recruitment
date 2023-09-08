using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.Services;

namespace Sat.Recruitment.Core.BussinesServices.User.Resultado
{
    public class ResultCreateUser : BaseResult<ContextCreateUser>
    {
        public ResultCreateUser(ContextCreateUser context) : base(context)
        {
        }

        public UserDto? User { get; set; }
    }
}
