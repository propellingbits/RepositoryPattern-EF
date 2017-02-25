using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// stores the web context with in particular scope
    /// </summary>
    /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
    public 
#if !DEBUG
        sealed 
#endif
        class ScopeObjectSourceManager<TObjectSource> : ObjectSourceManager<TObjectSource> where TObjectSource : class
    {
        /// <summary>
        /// Gets the scope options.
        /// </summary>
        /// <value>The scope options.</value>
        public override ScopeOption ScopeOption
        {
            get
            {
                return UnitOfWorkScope.ScopeOption;
            }
        }

        /// <summary>
        /// Gets the object source.
        /// </summary>
        /// <returns></returns>
        public override TObjectSource GetObjectSource() 
        {
            //Get the ObjectSource from the Unit of work scope.
            TObjectSource objectSource = (TObjectSource)UnitOfWorkScope.GetCurrentObjectSource<TObjectSource>();

            if (objectSource != null)
            {
                //return the object source from the current scope
                return objectSource;

            }
            else
            {
                //No scope defined for the current operation. Return a new object context from the object source factory.
                return EnterpriseLibraryContainer.Current.GetInstance<TObjectSource>();
                //return ServiceLocator.Current.GetInstance<TObjectSource>(name);  // Keep a reference to the ObjectSource to perform clean up later.  
            }
        }

    }
}

