using System.Collections.Generic;
using System.Data.Objects;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// stores the web context for desktop apps
    /// </summary>
    /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
    public 
#if !DEBUG
        sealed 
#endif
        class StaticObjectSourceManager<TObjectSource> : ObjectSourceManager<TObjectSource> where TObjectSource : class
    {
        private static object _lock = new object();
        private static readonly Dictionary<string, TObjectSource> _objectSourceDictionary = new Dictionary<string, TObjectSource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticObjectSourceManager&lt;TObjectSource&gt;"/> class.
        /// </summary>
        public StaticObjectSourceManager() : base() { }

        /// <summary>
        /// Gets the scope options.
        /// </summary>
        /// <value>The scope options.</value>
        public override ScopeOption ScopeOption
        {
            get
            {
                //StaticObjectSourceManager not intended to support unit of work.
                return ScopeOption.None;
            }
        }

        /// <summary>
        /// Gets the object source.
        /// </summary>
        /// <returns></returns>
        public override TObjectSource GetObjectSource()
        {
            string objectSourceName = typeof(TObjectSource).FullName;
            //Lock to ensure there is no two threads accessing which may cause two object contexts of the same name to be created.
            lock (_lock)
            {
                if (!_objectSourceDictionary.ContainsKey(objectSourceName))
                {
                    //this object context is cached for the whole lifespan of the application until the application is unload/terminated                    
                    _objectSourceDictionary.Add(objectSourceName, EnterpriseLibraryContainer.Current.GetInstance<TObjectSource>());
                }

                //Return the ObjectSource from the dictionary to the caller based on the  
                //context name supplied by the repository

                return (TObjectSource)_objectSourceDictionary[objectSourceName];

            }
        }
    }
}