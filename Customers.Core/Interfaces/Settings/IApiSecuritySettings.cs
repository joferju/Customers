using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Core.Interfaces.Settings
{
    public interface IApiSecuritySettings
    {
        string ApiId { get; set; }
        string ApiKey { get; set; }
    }
}
