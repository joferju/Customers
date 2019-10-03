using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Customers.Infrastructure.Data.Factories
{
    public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersContext>
    {
        public CustomersContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomersContext>();
#if DEBUG
            //builder.UseSqlServer("Server=tcp:moneymas-applications.database.windows.net,1433;Database=Applications;User Id=moneymas-admin;Password=vnepni9eBw6ncx9E9Lcn;");
            //builder.UseSqlServer("Server=DESKTOP-PNSALB5\\SQLEXPRESS;Database=Applications;User Id=moneymas-admin;Password=vnepni9eBw6ncx9E9Lcn;");
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;Connection Timeout=30;",
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(1000).TotalSeconds));
#else
           builder.UseSqlServer("Server=tcp:moneymas-applications.database.windows.net,1433;Database=Applications;User Id=moneymas-admin;Password=vnepni9eBw6ncx9E9Lcn;Connection Timeout=30;",
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(1000).TotalSeconds));
          // builder.UseSqlServer("Server=tcp:moneymas-applications-test.database.windows.net,1433;Database=Applications-Test;User Id=moneymas-admin;Password=uXzqOwE0tGGUrSd67MQg;");
#endif
            return new CustomersContext(builder.Options);
        }
    }
}
