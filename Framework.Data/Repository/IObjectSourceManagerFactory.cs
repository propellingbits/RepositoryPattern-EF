using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObjectSourceManagerFactory
    {
        /// <summary>
        /// Gets the object source manager.
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        IObjectSource<TObjectSource> GetObjectSourceManager<TObjectSource>() where TObjectSource : class; 
    }
}
