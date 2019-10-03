using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Core.Interfaces
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
    }
}
