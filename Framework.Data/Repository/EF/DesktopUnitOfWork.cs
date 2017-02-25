using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// Business Unit of Work to be used in non web application to provide unit of work pattern implementation.
    /// </summary>
    public 
#if !DEBUG
        sealed 
#endif
        class DesktopUnitOfWork : UnitOfWork
    {
        //To keep all the references of the ObjectSource available to the current unit of work
        private Dictionary<object, ObjectContext> _objectSourceDictionary = new Dictionary<object, ObjectContext>();

        /// <summary>
        /// Gets the object sources.
        /// </summary>
        /// <value>The object sources.</value>
        protected override IDictionary ObjectSources
        {
            get
            {
                return _objectSourceDictionary;
            }
        }
    }
}
