using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.BussinesServices.User.Resultado;

namespace Sat.Recruitment.Core.Interfaces.Services
{
    public interface IUserService
    {
        ResultGetUser GetUser(ContextGetUser contexto);
        ResultGetUsers GetUsers(ContextGetUsers contexto);
        ResultCreateUser CreateUser(ContextCreateUser contexto);
    }
}