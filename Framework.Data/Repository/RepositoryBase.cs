using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Data.Repository
{
    /// <summary>
    /// Repository abstract base class which must be implemented by the concrete repository.
    /// It provides the abstraction that the client component can program against directly and
    /// in the mean time serves as an interface that its child type must implement.
    /// </summary>
    /// <typeparam name="TEntity">The type of the Entity Object</typeparam>    
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>, IQueryable<TEntity>, IDisposable
        where TEntity : class        
    {
        ///// <summary>
        ///// Abstract method implemented by the sub type to create a new Entity object
        ///// </summary>
        ///// <returns>Entity object of type <typeparamref name="TEntity"/></returns>
        //protected internal abstract string ObjectSourceName { get; }


        ///// <summary>
        ///// Gets or sets the object source.
        ///// </summary>
        ///// <value>The object source.</value>
        //protected internal abstract object ObjectSource { get; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public abstract TEntity GetByKey(TEntity entity);

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="KeyValue">The key value.</param>
        /// <returns></returns>
        public abstract TEntity GetByKey(string keyName, object KeyValue);
                
        //public abstract TEntity GetByKey(IEnumerable<EntityKeyMember> entityKeyMembers);

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entityKeyMembers">The entity key members.</param>
        /// <returns></returns>
        public abstract TEntity GetByKey(IEnumerable<KeyValuePair<string, object>> entityKeyMembers);

        /// <summary>
        /// Abstract method implemented by the sub type to create a new Entity object
        /// </summary>
        /// <returns>Entity object of type <typeparamref name="TEntity"/></returns>
        public abstract TEntity Create();        

        /// <summary>
        /// Abstract method implemented by the sub type to add the Entity Object to the Repository
        /// </summary>
        /// <param name="entity">The Entity object to add</param>
        public abstract long Add(TEntity entity);

        /// <summary>
        /// Abstract method implemented by the sub type to update changes made to the Entity object in the repository
        /// </summary>
        /// <param name="entity">The Entity object to update</param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Abstract method implemented by the sub type to delete the Entity object from the repository
        /// </summary>
        /// <param name="entity">The Entity object to delete</param>
        public abstract void Delete(TEntity entity);        

        /// <summary>
        /// Abstract method implemented by the sub type to find Entity object(s) based on specification.  
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Find(ISpecification<TEntity> specification);

        /// <summary>
        /// Abstract method implemented by the sub type to find Entity object(s) based on expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression); //Enable the use of Repository.Find( x = x.property > 0);                

        /// <summary>
        /// Gets the repository query.
        /// </summary>
        /// <value>The repository query.</value>
        protected internal abstract IQueryable<TEntity> RepositoryQuery { get; }


        #region IEnumerable<TEntity> Members

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return RepositoryQuery.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return RepositoryQuery.GetEnumerator();
        }

        #endregion

        #region IQueryable Members

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable"/> is executed.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"/> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.</returns>
        public Type ElementType
        {
            get
            {
                return RepositoryQuery.ElementType;
            }
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Linq.Expressions.Expression"/> that is associated with this instance of <see cref="T:System.Linq.IQueryable"/>.</returns>
        public Expression Expression
        {
            get
            {
                return RepositoryQuery.Expression;
            }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Linq.IQueryProvider"/> that is associated with this data source.</returns>
        public IQueryProvider Provider
        {
            get
            {
                return RepositoryQuery.Provider;
            }
        }

        #endregion


        #region IDisposable Members


        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <remarks>
        /// Method is abstract because there is no need for implementation here. We just want to force derived classes to implement this method.
        /// </remarks>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RepositoryBase&lt;TEntity&gt;"/> is reclaimed by garbage collection.
        /// </summary>
        ~RepositoryBase()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }       
        #endregion

    }
}

