using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.TotalPrice)
               .HasPrecision(14, 2);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(c => c.CreatedOrders)
               .HasForeignKey(fk => fk.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.LastUpdatedBy)
               .WithMany(c => c.UpdatedOrders)
               .HasForeignKey(fk => fk.LastUpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.OrderBy)
               .WithMany(u => u.PlaceOders)
               .HasForeignKey(fk => fk.OrderByUserId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

           
        }
    }
}
