using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Data.Repository;

namespace ChildSupport.Dal
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected IRepository<T> _genericRepository;

        protected RepositoryBase(IRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T GetByKey(T entity)
        {
            return _genericRepository.GetByKey(entity);
        }

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="KeyValue">The key value.</param>
        /// <returns></returns>
        public T GetByKey(string keyName, object KeyValue)
        {
            return _genericRepository.GetByKey(keyName, KeyValue);
        }
        
        /*public T GetByKey(IEnumerable<EntityKeyMember> entityKeyMembers)
        {
            return _genericRepository.GetByKey(entityKeyMembers);
        }*/

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entityKeyMembers">The entity key members.</param>
        /// <returns></returns>
        public T GetByKey(IEnumerable<KeyValuePair<string, object>> entityKeyMembers)
        {
            return _genericRepository.GetByKey(entityKeyMembers);
        }

        /// <summary>
        /// Return a new object from the Object Services.
        /// </summary>
        /// <returns></returns>
        public T Create()
        {
            //return the proxy object for our POCO entity type if change tracking with notification is used. ProxyCreationEnabled=True
            return _genericRepository.Create();
        }

        /// <summary>
        /// Insert a new object.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>The count that indicates no of rows affected in the underlying persistence storage</returns>
        public long Add(T entity)
        {
            return _genericRepository.Add(entity);
        }

        /// <summary>
        /// Update the details of the object
        /// </summary>
        /// <param name="entity">entity object to update.</param>
        /// <returns>The count that indicates no of rows affected in the underlying persistence storage</returns>
        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }

        /// <summary>
        /// Delete/Remove the object.
        /// </summary>
        /// <param name="entity">The entity object to delete</param>
        /// <returns>The count that indicates no of rows affected in the underlying persistence storage</returns>
        public void Delete(T entity)
        {
            _genericRepository.Delete(entity);
        }

        public IEnumerable<T> Find(ISpecification<T> specification)
        {
            return _genericRepository.Find(specification).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Find(expression);
        }
    }
}