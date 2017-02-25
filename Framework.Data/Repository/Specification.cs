using System;
using System.Linq.Expressions;

namespace Framework.Data.Repository
{
    /// <summary>
    /// Specification pattern base type.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {

        private readonly Expression<Func<TEntity, bool>> _predicate;


        /// <summary>
        /// Initializes a new instance of the <see cref="Specification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public Specification(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;

        }

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Expression<Func<TEntity, bool>> Predicate
        {
            get { return _predicate; }

        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified entity]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(TEntity entity)
        {
            return _predicate.Compile().Invoke(entity);

        }

    }
}
