using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Customers.Core.Interfaces;
using Customers.Core.Services;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.Data.Interfaces;
using Customers.Infrastructure.Data.Repositories;
using Customers.Objects.Objects;

namespace Customers.Infrastructure.DependencyBuilder
{
    public static class DependencyBuilder
    {
        public static void AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddSingleton<IDbSettings>(configuration.BindSettings<DbSettings>(Constants.CustomersContext));
            services.AddDbContext<CustomersContext>(options => options.UseSqlServer(configuration.BindSettings<DbSettings>(Constants.CustomersContext).ConnectionString), ServiceLifetime.Transient);
            services.AddTransient<ICustomersContext, CustomersContext>();

            // DI Settings
           
            
            // DI Services
            services.AddTransient<ICustomersService, CustomersService>();
            

            
            // MappingExisting
            
            

            

            // Service Client
            

            // 3rd Party Services
            

            // DI Repositories
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            
        }
    }
}
