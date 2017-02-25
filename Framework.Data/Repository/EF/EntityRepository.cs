using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// It provides the abstraction that the client component can program against directly
    /// </summary>
    /// <typeparam name="TEntity">The type of the Entity Object</typeparam>
    /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public 
#if !DEBUG
        sealed 
#endif
        class EntityRepository<TEntity, TObjectSource> : RepositoryBase<TEntity>
        where TEntity : class
        where TObjectSource : ObjectContext
    {

        private bool disposed = false;
        private readonly PluralizationService _pluralizer;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository&lt;TEntity,TObjectSource&gt;"/> class.
        /// </summary>
        public EntityRepository()
        {            
            ObjectSourceManager<TObjectSource> objectSourceManager = (ObjectSourceManager<TObjectSource>)ServiceLocator.Current.GetInstance<IObjectSourceManagerFactory>("ObjectSourceManagerFactory").GetObjectSourceManager<TObjectSource>();
            
            if (objectSourceManager == null)
                throw new NullReferenceException("objectSourceManager is null.");

            _objectSourceManager = objectSourceManager;
            _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));  
        }

        #endregion

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public override TEntity Create()
        {
            return this.ObjectSet.CreateObject();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        private void Save()
        {
            if (ObjectSourceLifetimeManager.ScopeOption != ScopeOption.SaveAllWhenScopeEnds)
                ObjectSource.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override long Add(TEntity entity)
        {
            ValidateEntity(entity);
            this.ObjectSet.AddObject(entity);
            this.Save();
            EntityKey key = GetEntityKey(entity);            
            this.ObjectSet.Detach(entity);
            return long.Parse(key.EntityKeyValues.SingleOrDefault().Value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override void Update(TEntity entity)
        {
            ValidateEntity(entity);
            ObjectSet.Attach(entity);            
            ObjectSource.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            if (ObjectSourceLifetimeManager.ScopeOption != ScopeOption.SaveAllWhenScopeEnds)
                this.Save();            
            ObjectSet.Detach(entity);            
        }
        
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override void Delete(TEntity entity)
        {
            ObjectSet.Attach(entity);
            ObjectSource.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            if (ObjectSourceLifetimeManager.ScopeOption != ScopeOption.SaveAllWhenScopeEnds)
                this.Save();
            ObjectSet.Detach(entity);            
        }

        /// <summary>
        /// Gets the entity key for the POCO Entity type.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private EntityKey GetEntityKey(TEntity entity)
        {
            ReadOnlyMetadataCollection<EdmMember> keyMembers = this.ObjectSet.EntitySet.ElementType.KeyMembers;

            var entityKeyMembers = new List<EntityKeyMember>();

            //Construct the entity key for the POCO Entity type object.
            foreach (EdmMember keyMember in keyMembers)
            {
                object keyMemberValue = entity.GetType().GetProperty(keyMember.Name).GetValue(entity, null);
                entityKeyMembers.Add(new EntityKeyMember(keyMember.Name, keyMemberValue));
            }
            
            //Create the Entity key for our POCO Entity type object.
            return new EntityKey(this.ObjectSource.DefaultContainerName
                + "." + this.ObjectSet.EntitySet.Name, entityKeyMembers);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<TEntity> GetAll()
        {
            return Find(e => true);
        }

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override TEntity GetByKey(TEntity entity)
        {
            //Create the Entity key for POCO TEntity type object.
            EntityKey entityKey = GetEntityKey(entity);
            object foundEntity; // the following method expect 2nd param of type object
            return this.ObjectSource.TryGetObjectByKey(entityKey, out foundEntity) ? foundEntity as TEntity : null;
        }

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="KeyValue">The key value.</param>
        /// <returns></returns>
        public override TEntity GetByKey(string keyName, object KeyValue)
        {
            //Creates the Entity key for POCO TEntity type object.
            EntityKey entityKey = new EntityKey(this.ObjectSource.DefaultContainerName + "." + this.ObjectSet.EntitySet.Name, keyName, KeyValue);
            object entity; // the following method expect 2nd param of type object
            return this.ObjectSource.TryGetObjectByKey(entityKey, out entity) ? entity as TEntity : null;
        }
        
        /*public override TEntity GetByKey(IEnumerable<EntityKeyMember> entityKeyMembers)
        {
            //Creates the Entity key for POCO TEntity type object.
            EntityKey entityKey = new EntityKey(this.ObjectSource.DefaultContainerName + "." + this.ObjectSet.EntitySet.Name, entityKeyMembers);
            object entity; // the following method expect 2nd param of type object
            return this.ObjectSource.TryGetObjectByKey(entityKey, out entity) ? entity as TEntity : null;
        }*/

        /// <summary>
        /// Gets the TEntity by key.
        /// </summary>
        /// <param name="entityKeyMembers">The entity key members.</param>
        /// <returns></returns>
        public override TEntity GetByKey(IEnumerable<KeyValuePair<string, object>> entityKeyMembers)
        {
            //Creates the Entity key for POCO TEntity type object.
            EntityKey entityKey = new EntityKey(this.ObjectSource.DefaultContainerName + "." + this.ObjectSet.EntitySet.Name, entityKeyMembers);
            object entity; // the following method expect 2nd param of type object
            return this.ObjectSource.TryGetObjectByKey(entityKey, out entity) ? entity as TEntity : null;
        }

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public override IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            return InternalFind(specification);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public override IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression) //Enable the use of Repository.Find( x = x.property > 0);
        {
            return InternalFind(new Specification<TEntity>(expression));
        }

        private IQueryable<TEntity> InternalFind(ISpecification<TEntity> specification)
        {
            ObjectSet.MergeOption = MergeOption.NoTracking;
            return RepositoryQuery.Where(specification.Predicate);
        }

        private static void ValidateEntity(TEntity entity)
        {
            ValidationResults results = Validation.Validate<TEntity>(entity);
            if (results != null && results.Count > 0)
                throw new Framework.Data.Repository.EF.EntityValidationException(results);
        }

        /// <summary>
        /// Gets the repository query.
        /// </summary>
        /// <value>The repository query.</value>
        protected internal override IQueryable<TEntity> RepositoryQuery
        {
            get
            {
                return this.ObjectSet.AsQueryable();
            }
        }

        #region Context Members

        private ObjectSourceManager<TObjectSource> _objectSourceManager = null;
        private ObjectContext _objectSource = null;
        private ObjectSet<TEntity> _objectSet = null;

        private ObjectSourceManager<TObjectSource> ObjectSourceLifetimeManager
        {
            get { return _objectSourceManager; }
        }

        /// <summary>
        /// Gets the name of the object source.
        /// </summary>
        /// <value>The name of the object source.</value>
        protected internal TObjectSource ObjectSourceName { get; private set; }

        /// <summary>
        /// Gets the object source.
        /// </summary>
        /// <value>The object source.</value>
        protected internal ObjectContext ObjectSource
        {
            get
            {
                if (_objectSource == null)
                {
                    _objectSource = _objectSourceManager.GetObjectSource();
                }
                return _objectSource;
            }
        }

        private ObjectSet<TEntity> ObjectSet
        {
            get
            {
                if (_objectSet == null)
                {
                    //Assuming that the ObjectSet has a plural names of the entity names it keeps.
                    _objectSet = (ObjectSet<TEntity>)ObjectSource.GetType().GetProperty(_pluralizer.Pluralize(typeof(TEntity).Name)).GetValue(ObjectSource, null);
                }
                return _objectSet;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        // The derived class does not have a Finalize method
        // or a Dispose method without parameters because it inherits
        // them from the base class.
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                    _objectSource.Dispose();                    
                }
                // Release unmanaged resources.
                // Set large fields to null.
                // Call Dispose on your base class.
                disposed = true;
            }
            //base.Dispose(disposing);
        }
    }
        #endregion
}
