using Sat.Recruitment.Core.Interfaces.Entities;
using System.Linq.Expressions;

namespace Sat.Recruitment.Core.Interfaces.Repositories.Generics
{
    public interface IQuery<TEntity> where TEntity : IBaseEntity
    {
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? where);
    }

}
