using System.Data.Objects;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// stores the object context for web requests
    /// </summary>
    /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
    public 
#if !DEBUG
        sealed 
#endif
        class WebObjectSourceManager<TObjectSource> : ObjectSourceManager<TObjectSource> where TObjectSource : class
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WebObjectSourceManager&lt;TObjectSource&gt;"/> class.
        /// </summary>
        public WebObjectSourceManager() : base() { }


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
            return (TObjectSource)UnitOfWorkScope.GetCurrentObjectSource<TObjectSource>();
        }
    }
}
