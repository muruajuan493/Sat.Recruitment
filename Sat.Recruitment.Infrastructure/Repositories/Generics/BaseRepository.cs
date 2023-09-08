using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Core.Generics.Entities;
using Sat.Recruitment.Core.Interfaces.Repositories.Generics;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Infrastructure.Repositories.Generics;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Sat.Recruitment.Infrastructure.Repositories.Generics
{

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>, IQuery<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        ///     Devuelve una lista de elementos completa siempre que esten activos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        ///     Devuelve un elemento siempre que este activo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? GetById(int id)
        {
            return _dbSet.SingleOrDefault(a => a.Id == id);
        }

        /// <summary>
        ///     Devuelve una lista de elementos que cumplan con las condiciones de la clase filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindByFilter(IFilter<TEntity> filter)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter.WhereCondition != null)
            {
                query = query.Where(filter.WhereCondition);
            }

            if (string.IsNullOrEmpty(filter.IncludeProperties))
            {
                foreach (var includeProperty in filter.IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter.OrderBy != null)
            {
                return filter.OrderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        ///     Devuelve una lista de elementos que cumplan con las condiciones enviadas.
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindByFilter(Expression<Func<TEntity, bool>>? whereCondition = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Any(where);
        }

        /// <summary>
        ///     Devuelve una expresión de consulta que, cuando se enumera, recuperará todos los objetos.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Query()
        {
            return Query(null);
        }

        /// <summary>
        ///     Devuelve una expresión de consulta que, cuando se enumera, recuperará solo los objetos que cumplan la condición where.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? where)
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return query;
        }

        /// <summary>
        ///     Guarda los cambios del rastreador de cambios de DbContext en la base de datos.
        /// </summary>
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        ///     Marca una entidad para su eliminación en el rastreador de cambios de DbContext si pasa el método ValidateDelete.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Delete(TEntity entity)
        {
            var deleteErrors = ValidateDelete(entity);

            if (deleteErrors.Any())
            {
                return deleteErrors;
            }

            _dbSet.Update(entity);

            return Enumerable.Empty<ValidationResult>();
        }
        public IEnumerable<ValidationResult> DeleteRange(IEnumerable<TEntity> entities)
        {
            var deleteErrors = entities.Select(entity => ValidateDelete(entity));

            if (deleteErrors.All(dErr => dErr.Any()))
            {
                return deleteErrors.First();
            }

            _dbSet.UpdateRange(entities);

            return Enumerable.Empty<ValidationResult>();
        }

        /// <summary>
        ///     Agrega una entidad para la inserción en el rastreador de cambios de DbContext si no se encuentran errores en el método ValidateSave.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Insert(TEntity entity)
        {
            var saveErrors = ValidateSave(entity);

            if (saveErrors.Any())
            {
                return saveErrors;
            }

            _dbSet.Add(entity);

            return Enumerable.Empty<ValidationResult>();
        }
        public IEnumerable<ValidationResult> InsertRange(IEnumerable<TEntity> entities)
        {
            var saveErrors = entities.Select(entity => ValidateSave(entity));

            if (saveErrors.All(dErr => dErr.Any()))
            {
                return saveErrors.First();
            }

            _dbSet.AddRange(entities);

            return Enumerable.Empty<ValidationResult>();
        }

        /// <summary>
        ///     Marca una entidad para su actualización en el rastreador de cambios de DbContext si pasa el método ValidateSave.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Update(TEntity entity)
        {
            var saveErrors = ValidateSave(entity);

            if (saveErrors.Any())
            {
                return saveErrors;
            }

            _dbSet.Update(entity);

            return Enumerable.Empty<ValidationResult>();
        }
        public IEnumerable<ValidationResult> UpdateRange(IEnumerable<TEntity> entities)
        {
            var saveErrors = entities.Select(entity => ValidateSave(entity));

            if (saveErrors.All(dErr => dErr.Any()))
            {
                return saveErrors.First();
            }

            _dbSet.UpdateRange(entities);

            return Enumerable.Empty<ValidationResult>();
        }

        /// <summary>
        ///     Llama a Insert o Update según corresponda, según el valor de la propiedad Id;
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Upsert(TEntity entity)
        {
            if (entity.Id == 0)
            {
                return Insert(entity);
            }
            else
            {
                return Update(entity);
            }
        }

        /// <summary>
        ///     Valida si está bien eliminar la entidad de la base de datos.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual IEnumerable<ValidationResult> ValidateDelete(TEntity model)
        {
            yield break;
        }

        /// <summary>
        ///     Valida si está bien guardar la entidad nueva o actualizada en la base de datos.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual IEnumerable<ValidationResult> ValidateSave(TEntity model)
        {
            yield break;
        }
    }
}
