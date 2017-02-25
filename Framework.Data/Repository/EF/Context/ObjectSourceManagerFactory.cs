
namespace Framework.Data.Repository.EF.Context
{
    /// <summary>
    /// Object Source Manager Factory
    /// </summary>
    public class ObjectSourceManagerFactory : IObjectSourceManagerFactory
    {
        /// <summary>
        /// Gets the object source manager.
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        public IObjectSource<TObjectSource> GetObjectSourceManager<TObjectSource>() where TObjectSource : class
        {
            switch ((ObjectSourceManagerTypes)Properties.Settings.Default.ObjectSourceManagerType)
            {
                case ObjectSourceManagerTypes.Scope:
                    return new ScopeObjectSourceManager<TObjectSource>();                    
                case ObjectSourceManagerTypes.Static:
                    return new StaticObjectSourceManager<TObjectSource>();                    
                case ObjectSourceManagerTypes.Web:
                    return new WebObjectSourceManager<TObjectSource>();                    
            }

            return null;
        }
    }
}
