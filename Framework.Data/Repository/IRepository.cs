using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Framework.Data.Repository
{
    /// <summary>
    /// Generic Repository Pattern Interface
    /// </summary>
    /// <typeparam name="TEntity">A POCO Entity Type</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Create a new Entity Object
        /// </summary>
        /// <returns>Entity object of type <typeparamref name="TEntity"/></returns>
        TEntity Create();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity GetByKey(TEntity entity);

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="KeyValue">The key value.</param>
        /// <returns></returns>
        TEntity GetByKey(string keyName, object KeyValue);
                
        //TEntity GetByKey(IEnumerable<EntityKeyMember> entityKeyMembers);

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entityKeyMembers">The entity key members.</param>
        /// <returns></returns>
        TEntity GetByKey(IEnumerable<KeyValuePair<string, object>> entityKeyMembers);

        /// <summary>
        /// Add the Entity Object to the Repository
        /// </summary>
        /// <param name="entity">The Entity object to add</param>
        long Add(TEntity entity);        
        
        /// <summary>
        /// Update changes made to the Entity object in the repository
        /// </summary>
        /// <param name="entity">The Entity object to update</param>
        void Update(TEntity entity);
        
        /// <summary>
        /// Delete the Entity object from the repository
        /// </summary>
        /// <param name="entity">The Entity object to delete</param>
        void Delete(TEntity entity);        

        /// <summary>
        /// Find the Entity object(s) based on specification.
        /// </summary>
        /// <param name="specification"></param>
        IEnumerable<TEntity> Find(ISpecification<TEntity> specification);

        /// <summary>
        /// Find the Entity object(s) based on user supplied lambda expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);        
    }
}
