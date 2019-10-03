using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Customers.Infrastructure.Data.DbMapping;
using Customers.Infrastructure.Data.Interfaces;
using Customers.Objects.Objects;

namespace Customers.Infrastructure.Data
{
    public sealed class CustomersContext : DbContext, ICustomersContext
    {
        public CustomersContext(DbContextOptions options)
            : base(options)
        {
            DataBase = Database;
        }

        public DbSet<CustomersData> CustomersData { get; set; }

        public DatabaseFacade DataBase { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCustomersData();
        }
    }
}
