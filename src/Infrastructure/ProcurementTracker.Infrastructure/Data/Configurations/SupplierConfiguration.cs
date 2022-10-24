using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");

            builder.HasKey(x => x.Id);

            builder.HasOne<User>(u => u.CreatedBy)
              .WithMany(c => c.CreatedSuppliers)
              .HasForeignKey(fk => fk.CreatedById)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired(true);

            builder.HasOne<User>(u => u.LastUpdatedBy)
               .WithMany(c => c.UpdatedSuppliers)
               .HasForeignKey(fk => fk.LastUpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);
        }
    }
}
