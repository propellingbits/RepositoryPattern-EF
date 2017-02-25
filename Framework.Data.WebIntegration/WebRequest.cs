using System;
using System.Web;
using System.Collections;

namespace Framework.Data.WebIntegration
{
    /// <summary>
    /// Singleton class that encapsulates the HttpContext.
    /// </summary>
    public class WebRequest
    {
        private HttpContextBase _httpContext;
        private static WebRequest _instance = new WebRequest();

        /// <summary>
        /// When testing, call this internal constructor to pass in a fake HttpContext.
        /// </summary>
        /// <param name="httpContext"></param>
        internal WebRequest(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        /// <summary>
        /// In production, this constructor gets called by the static field initializer for _instance.
        /// </summary>
        internal WebRequest()
        {
            if (HttpContext.Current != null)
                _httpContext = new HttpContextWrapper(HttpContext.Current);
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IDictionary Items
        {
            get
            {
                return _httpContext.Items;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static WebRequest Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}