using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.Helper
{
    public class BasicAuthHandle : AuthorizationHandler<BasicAuthHandle>, IAuthorizationRequirement
    {

        #region [Fields]

        /// <summary>
        /// The HttpContext.
        /// </summary>
        IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// The authentication type.
        /// </summary>
        private const string AUTH_TYPE = "Basic";

        /// <summary>
        /// The Request header fields.
        /// </summary>
        private const string HEADER_PARAM = "Authorization";

        #endregion

        #region [Constructors]

        public BasicAuthHandle(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region [Methods]

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BasicAuthHandle requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        private bool IsAuthenticate()
        {
            bool result = false;

            var httpcontext = _httpContextAccessor.HttpContext;
            string authHeader = httpcontext.Request.Headers[HEADER_PARAM];
            if (authHeader != null && authHeader.StartsWith(AUTH_TYPE))
            {
                string encodeParameter = authHeader.Substring(AUTH_TYPE.Length).Trim();
                var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodeParameter)).Split(':');
            }

            return result;
        }

        #endregion
        
    }
}
