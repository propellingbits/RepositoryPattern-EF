
namespace Framework.Data.Repository
{
    /// <summary>
    /// Object Source Manager Types
    /// </summary>
    public enum ObjectSourceManagerTypes
    {
        /// <summary>
        /// defines enum type for creating instance of ScopeObjectSourceManager class
        /// </summary>
        Scope=1,
        /// <summary>
        /// defines enum type for creating instance of StaticObjectSourceManager class
        /// </summary>
        Static,
        /// <summary>
        /// defines enum type for creating instance of WebObjectSourceManager class
        /// </summary>
        Web
    }

    /// <summary>
    /// Abstract class that must be implemented by the class that manage the lifespan of the ObjectSource
    /// </summary>
    /// <typeparam name="TObjectSource"></typeparam>
    public abstract class ObjectSourceManager<TObjectSource> : IObjectSource<TObjectSource> where TObjectSource : class
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSourceManager&lt;TObjectSource&gt;"/> class.
        /// </summary>
        protected ObjectSourceManager() { }

        /// <summary>
        /// Gets the scope options.
        /// </summary>
        /// <value>The scope options.</value>
        public abstract ScopeOption ScopeOption { get; }

        /// <summary>
        /// Gets the object source.
        /// </summary>
        /// <returns></returns>
        public abstract TObjectSource GetObjectSource();        
    }
}
