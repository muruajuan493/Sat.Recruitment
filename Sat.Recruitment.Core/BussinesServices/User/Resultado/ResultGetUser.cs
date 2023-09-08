using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.Services;

namespace Sat.Recruitment.Core.BussinesServices.User.Resultado
{
    public class ResultGetUser : BaseResult<ContextGetUser>
    {
        public ResultGetUser(ContextGetUser contexto) : base(contexto)
        {
        }

        public UserDto? User { get; set; }
    }
}
