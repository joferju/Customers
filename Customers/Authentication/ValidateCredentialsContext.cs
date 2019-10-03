using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Customers.Authentication
{
    public class ValidateCredentialsContext
    {
        private readonly ApiSecuritySettings _options;

        /// <summary>
        /// Creates a new instance of <see cref="ValidateCredentialsContext"/>.
        /// </summary>
        /// <param name="options">The <see cref="ApiSecuritySettings"/> for this instance.</param>
        public ValidateCredentialsContext(ApiSecuritySettings options)
        {
            _options = options;
        }

        /// <summary>
        /// The user name to validate.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password to validate.
        /// </summary>
        public string Password { get; set; }

        public AuthenticationTicket ValidateCredentials(string defaultScheme)
        {
            if (Username == _options.ApiId && Password == _options.ApiKey)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, Username),
                    new Claim(ClaimTypes.Name, Username)
                };

                return new AuthenticationTicket(
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, defaultScheme)),
                    new AuthenticationProperties(),
                    defaultScheme);
            }
            return null;
        }
    }
}
