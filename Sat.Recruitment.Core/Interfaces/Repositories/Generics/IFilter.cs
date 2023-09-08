using System.Linq.Expressions;

namespace Sat.Recruitment.Core.Interfaces.Repositories.Generics
{
    public interface IFilter<TEntity>
    {
        public Expression<Func<TEntity, bool>>? WhereCondition { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; set; }
        public string IncludeProperties { get; set; }
    }
}
