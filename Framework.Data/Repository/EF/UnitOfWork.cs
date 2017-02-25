using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Reflection;
using System.Transactions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Globalization;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// unit of work abstract base class
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase
    {
        private bool disposed = false;

        //To keep all the references of the ObjectSources available to the current unit 
        //of work. 

        /// <summary>
        /// Gets the object sources.
        /// </summary>
        /// <value>The object sources.</value>
        protected abstract IDictionary ObjectSources { get; }

        private Dictionary<string, bool> _markForDisposal = new Dictionary<string, bool>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"></see> class.
        /// </summary>
        protected UnitOfWork() { }


        /// <summary>
        /// Commit the Unit of Work for the Entity Framework
        /// </summary>
        /// <returns>Number of logical records affected by the current commit</returns>
        public override int Commit()
        {
            int count = 0;
            //loop through the dictionary and persist the changes through the object context
            //inside the transaction scope.
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (ObjectContext objectSource in ObjectSources.Values)
                {
                    count += objectSource.SaveChanges(SaveOptions.None);
                    objectSource.AcceptAllChanges();
                }

                transactionScope.Complete(); //commit the transaction.
            }
            return count;
        }

        /// <summary>
        /// Add the ObjectSource into the Unit of Work for Entity Framework
        /// </summary>
        /// <param name="repository">The repository.</param>
        public override void AddObjectSource<TEntity, TObjectSource>(RepositoryBase<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "repository is null.");

            EntityRepository<TEntity, ObjectContext> entityRepository = repository as EntityRepository<TEntity, ObjectContext>;
            if (entityRepository == null)
            {
                string typeName = repository.GetType().FullName;
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture,
                    "Excepted an EntityRepository<TEntity> but was {0}", typeName), "repository");
            }

            string objectSourceName = entityRepository.ObjectSourceName.ToString();
            ObjectContext objectSourceLoaded = entityRepository.ObjectSource;

            //Add the ObjectSource instance into the dictionary if it is empty
            if (ObjectSources.Values.Count == 0)
            {
                ObjectSources.Add(objectSourceName, objectSourceLoaded);
                _markForDisposal.Add(objectSourceName, false);
            }
            //check whether we already have the ObjectSource instance identified by the name key in our ObjectContext dictionary.
            else if (ObjectSources.Contains(objectSourceName))
            {
                //get the ObjectSource instance identified by the name key from the 
                Object tempObjectSource = ObjectSources[objectSourceName];

                if (!objectSourceLoaded.Equals(tempObjectSource))
                {
                    // throw exception here
                    throw new UnitOfWorkException("Different ObjectSource instance for the same key name");
                }
                else
                {
                    _markForDisposal[objectSourceName] = false;
                }
            }
            else
            {
                //Just add the ObjectSource instance with the key name
                ObjectSources.Add(objectSourceName, objectSourceLoaded);
                _markForDisposal.Add(objectSourceName, false);
            }
        }


        /// <summary>
        /// Return the ObjectSource instance associated with the current Unit of Work.
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        /// <remarks>
        /// An object source provides information about the object"s persistence.
        /// </remarks>
        public override TObjectSource GetObjectSource<TObjectSource>()
        {
            string objectSourceName = typeof(TObjectSource).FullName;

            //return the object context from the dictionary
            if (ObjectSources.Contains(objectSourceName))
                return (TObjectSource)ObjectSources[objectSourceName];           

            //create the object context and add it to dictionary for reuse by other client in the same scope.
            ObjectSources.Add(objectSourceName, EnterpriseLibraryContainer.Current.GetInstance<TObjectSource>());
            _markForDisposal.Add(objectSourceName, true);
            return (TObjectSource)ObjectSources[objectSourceName];
        }

        /// <summary>
        /// Release all the Resources used by Unit of Work
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                    foreach (string key in ObjectSources.Keys)
                    {
                        if (_markForDisposal[key])
                        {
                            ((ObjectContext)ObjectSources[key]).Dispose();
                        }
                    }
                }
                // Release unmanaged resources.
                // Set large fields to null.
                // Call Dispose on your base class.
                disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}