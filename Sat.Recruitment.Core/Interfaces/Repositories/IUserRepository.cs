using Sat.Recruitment.Core.Entities.User;
using Sat.Recruitment.Core.Interfaces.Repositories.Generics;

namespace Sat.Recruitment.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        public virtual bool ValidateDuplicateUser(UserEntity user)
        {
            return false;
        }
    }
}
