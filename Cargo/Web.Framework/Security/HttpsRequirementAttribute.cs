using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Web.Framework.Security
{
    public enum SslRequirement
    {
        /// <summary>
        /// Page should be secured
        /// </summary>
        Yes,
        /// <summary>
        /// Page should not be secured
        /// </summary>
        No,
        /// <summary>
        /// It doesn't matter (as requested)
        /// </summary>
        NoMatter,
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class HttpsRequirementAttribute : FilterAttribute, IAuthorizationFilter
    {
        public SslRequirement SslRequirement { get; set; }

        public HttpsRequirementAttribute(SslRequirement sslRequirement)
        {
            this.SslRequirement = sslRequirement;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            //don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            // only redirect for GET requests, 
            // otherwise the browser might not propagate the verb and request body correctly.
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var currentConnectionSecured = filterContext.HttpContext.Request.IsSecureConnection;
            //TODO uncomment currentConnectionSecured = _webHelper.IsCurrentConnectionSecured();

            switch (this.SslRequirement)
            {
                case SslRequirement.Yes:
                    {
                        //todo...
                    }
                    break;
                case SslRequirement.No:
                    {
                        //todo..
                    }
                    break;
                case SslRequirement.NoMatter:
                    {
                        //do nothing
                    }
                    break;
                default:
                    throw new Exception("Not supported SslProtected parameter");
            }
        }
    }
}
