using System;
using System.Collections.Generic;
using System.Text;
using Customers.Core.Interfaces;

namespace Customers.Infrastructure.Data
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
    }
}
