using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Sat.Recruitment.Core.Interfaces.Repositories.Generics
{
    public interface IBaseRepository<TEntity>
    {
        TEntity? GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindByFilter(IFilter<TEntity> filter);
        IEnumerable<TEntity> FindByFilter(Expression<Func<TEntity, bool>>? whereCondition = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        bool Any(Expression<Func<TEntity, bool>> where);
        void SaveChanges();
        IEnumerable<ValidationResult> Delete(TEntity entity);
        IEnumerable<ValidationResult> DeleteRange(IEnumerable<TEntity> entity);
        IEnumerable<ValidationResult> Insert(TEntity entity);
        IEnumerable<ValidationResult> InsertRange(IEnumerable<TEntity> entity);
        IEnumerable<ValidationResult> Update(TEntity entity);
        IEnumerable<ValidationResult> UpdateRange(IEnumerable<TEntity> entity);
        IEnumerable<ValidationResult> Upsert(TEntity entity);
        IEnumerable<ValidationResult> ValidateDelete(TEntity model);
        IEnumerable<ValidationResult> ValidateSave(TEntity model);
    }
}
