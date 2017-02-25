using System;

namespace Framework.Data.Repository
{
    /// <summary>
    /// Abstract base class for UnitOfWork
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork, IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public abstract int Commit();

        /// <summary>
        /// Get the ObjectSource from the Unit of Work
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        /// <remarks>
        /// An object source provides information about the object"s persistence.
        /// </remarks>
        public abstract TObjectSource GetObjectSource<TObjectSource>() where TObjectSource : class;

        /// <summary>
        /// Add the ObjectSource into the Unit of Work
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <remarks>
        /// An object source provides information about the object"s persistence.
        /// </remarks>
        public abstract void AddObjectSource<TEntity, TObjectSource>(RepositoryBase<TEntity> repository) 
            where TEntity : class
            where TObjectSource : class;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="UnitOfWorkBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~UnitOfWorkBase()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}
