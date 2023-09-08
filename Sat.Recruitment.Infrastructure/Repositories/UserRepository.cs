using Sat.Recruitment.Core.Entities.User;
using Sat.Recruitment.Core.Interfaces.Repositories;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Infrastructure.Repositories.Generics;

namespace Sat.Recruitment.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public bool ValidateDuplicateUser(UserEntity user)
        {
            List<UserEntity> queryResult = Query(x => x.Name == user.Name || x.Email == user.Email || x.Phone == user.Phone).ToList();
            return queryResult.Any();
        }
    }
}
