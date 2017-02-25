using System.Collections;
using Framework.Data.Repository.EF;

namespace Framework.Data.WebIntegration
{
    /// <summary>
    /// Unit Of Work implementation for web requests
    /// </summary>
    public sealed class WebUnitOfWork : UnitOfWork
    {

        /// <summary>
        /// Gets the object sources.
        /// </summary>
        /// <value>The object sources.</value>
        protected override IDictionary ObjectSources
        {
            get
            {
                return WebRequest.Instance.Items;
            }
        }
    }
}
