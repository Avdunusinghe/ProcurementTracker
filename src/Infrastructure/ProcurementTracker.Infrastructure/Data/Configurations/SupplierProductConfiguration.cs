using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class SupplierProductConfiguration : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            builder.ToTable("SupplierProduct");

            builder.HasKey(x => x.Id);

            builder.HasOne<Supplier>(u => u.Supplier)
              .WithMany(c => c.SupplierProducts)
              .HasForeignKey(fk => fk.SupplierId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired(false);

            builder.HasOne<Product>(u => u.Product)
             .WithMany(c => c.SupplierProducts)
             .HasForeignKey(fk => fk.ProductId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);
        }
    }
}
