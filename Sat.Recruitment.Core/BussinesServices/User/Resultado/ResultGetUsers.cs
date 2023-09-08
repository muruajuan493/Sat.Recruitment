using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Generics.Services;

namespace Sat.Recruitment.Core.BussinesServices.User.Resultado
{
    public class ResultGetUsers : BaseResult<ContextGetUsers>
    {
        public ResultGetUsers(ContextGetUsers contexto) : base(contexto)
        {
        }

        public List<UserDto>? Users { get; set; }
    }
}
