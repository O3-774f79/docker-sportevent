using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.Extensions
{
    public class BasicAuthAttribute : ActionFilterAttribute
    {
        #region [Fields]

        /// <summary>
        /// The Roles.
        /// </summary>
        public string[] Roles { get; set; }

        /// <summary>
        /// The authentication type.
        /// </summary>
        private const string AUTH_TYPE = "Basic";

        /// <summary>
        /// The Request header fields.
        /// </summary>
        private const string HEADER_PARAM = "Authorization";

        /// <summary>
        /// The configuration.
        /// </summary>
        private IConfiguration _configuration;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthAttribute" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public BasicAuthAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// The AuthAttribute.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsAuthorized(filterContext.HttpContext.Request.Headers[HEADER_PARAM]))
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                filterContext.Result = new JsonResult(new
                {
                    ErrorFlag = true,
                    Message = "Unauthorized."
                });
            }
        }

        /// <summary>
        /// Validate username and password to authenticate.
        /// </summary>
        /// <param name="authHeader">The authentication header value.</param>
        /// <returns></returns>
        private bool IsAuthorized(string authHeader)
        {
            bool result = false;

            if (authHeader != null && authHeader.StartsWith(AUTH_TYPE))
            {
                string encodeParameter = authHeader.Substring(AUTH_TYPE.Length).Trim();
                var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodeParameter)).Split(':');
                if (usernamePassword[0] == _configuration["Basic:Username"] && usernamePassword[1] == _configuration["Basic:Password"])
                {
                    result = true;
                }

            }

            return result;
        }

        #endregion
        
    }
}
