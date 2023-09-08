using Sat.Recruitment.Core.Generics.Entities;
using Sat.Recruitment.Core.Interfaces.Repositories.Generics;
using System.Linq.Expressions;

namespace Sat.Recruitment.Infrastructure.Repositories.Generics
{
    public class Filter<TEntity> : IFilter<TEntity> where TEntity : BaseEntity
    {
        public Expression<Func<TEntity, bool>>? WhereCondition { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}
