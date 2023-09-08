using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sat.Recruitment.Core.Generics.Entities;
using Sat.Recruitment.Core.Interfaces.Repositories.Generics;
using Sat.Recruitment.Infrastructure.Repositories.Generics;
using System.Linq.Expressions;

namespace Sat.Recruitment.Infrastructure.Repositories.Generics
{

    public static class IQueryExtensions
    {
        /// <summary>
        ///     Returns the first object that satisfies the condition or raises InvalidaOperationException if none.
        /// </summary>
        public static TEntity First<TEntity>(this IQuery<TEntity> manager, Expression<Func<TEntity, bool>>? where = null) where TEntity : BaseEntity
        {
            return manager.Query(where).First();
        }

        /// <summary>
        ///     Returns the first object that satisfies the condition or null if none.
        /// </summary>
        public static TEntity? FirstOrDefault<TEntity>(this IQuery<TEntity> manager, Expression<Func<TEntity, bool>>? where = null) where TEntity : BaseEntity
        {
            return manager.Query(where).FirstOrDefault();
        }

        /// <summary>
        ///     <para>
        ///         Especifies the related objects to include in the query result and returns and IIncludableQueryable that allows chaining of other IQueryable methods.
        ///     </para>
        ///     <para>
        ///         For more information and examples visit:
        ///         https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_Include__2_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0___1___
        ///     </para>
        /// </summary>
        /// <param name="includeExpression">The navigation property to include</param>
        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQuery<TEntity> manager, Expression<Func<TEntity, TProperty>> includeExpression) where TEntity : BaseEntity
        {
            return manager.Query().Include(includeExpression);
        }

        /// <summary>
        ///     Returns the single object that satisfies the condition or raises InvalidaOperationException if none or more than one.
        /// </summary>
        public static TEntity Single<TEntity>(this IQuery<TEntity> manager, Expression<Func<TEntity, bool>>? where = null) where TEntity : BaseEntity
        {
            return manager.Query(where).Single<TEntity>();
        }

        /// <summary>
        ///     Returns the single object that satisfies the condition or null if none or raises InvalidaOperationException if more than one.
        /// </summary>
        public static TEntity? SingleOrDefault<TEntity>(this IQuery<TEntity> manager, Expression<Func<TEntity, bool>>? where = null) where TEntity : BaseEntity
        {
            return manager.Query(where).SingleOrDefault();
        }
    }
}
