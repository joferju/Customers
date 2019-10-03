using Microsoft.AspNetCore.Authentication;
using Customers.Core.Interfaces.Settings;

namespace Customers.Authentication
{
    public class ApiSecuritySettings : AuthenticationSchemeOptions, IApiSecuritySettings
    {
        public string ApiId { get; set; }
        public string ApiKey { get; set; }
    }
}
