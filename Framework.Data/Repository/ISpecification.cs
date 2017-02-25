using System;
using System.Linq.Expressions;


namespace Framework.Data.Repository
{
    /// <summary>
    /// Interface for Specification pattern.
    /// </summary>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// The criteria of the Specification.
        /// </summary>
        Expression<Func<TEntity, bool>> Predicate { get; }

        /// <summary>
        /// Return true/false whethe the Entity object meet the criteria encapsulated by the
        /// Specification.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsSatisfiedBy(TEntity entity);

    }
}
