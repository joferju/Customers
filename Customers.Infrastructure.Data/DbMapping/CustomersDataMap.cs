
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customers.Objects.Objects;

namespace Customers.Infrastructure.Data.DbMapping
{
    public static class CustomersDataMap
    {
        public static ModelBuilder MapCustomersData(this ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<CustomersData> entity = modelBuilder.Entity<CustomersData>();

            // Primary Key
            entity.HasKey(t => t.CustomersDataId);

            // Properties
            entity.Property(t => t.CustomersDataReference)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            

            // Table & Column Mappings
            entity.ToTable("Customers");
            entity.Property(t => t.CustomersDataId).UseSqlServerIdentityColumn();

            return modelBuilder;
        }
    }
}
