using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class PurchaseRequestConfiguration : IEntityTypeConfiguration<PurchaseRequest>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequest> builder)
        {
            builder.ToTable("PurchaseRequest");

            builder.HasKey(x => x.Id);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(c => c.CreatedPurchaseRequests)
               .HasForeignKey(fk => fk.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.LastUpdatedBy)
               .WithMany(c => c.UpdatedPurchaseRequests)
               .HasForeignKey(fk => fk.LastUpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.StatusChangedBy)
               .WithMany(c => c.StatusChangedPurchaseRequests)
               .HasForeignKey(fk => fk.LastUpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<Product>(u => u.Product)
              .WithMany(c => c.PurchaseRequests)
              .HasForeignKey(fk => fk.ProductId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired(false);

            builder.Property(t => t.TotalPrice)
               .HasPrecision(14, 2);




        }
    }
}
