using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(x => x.Id);

            builder.HasOne<Product>(u => u.Product)
               .WithMany(c => c.OrderItems)
               .HasForeignKey(fk => fk.ProductId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);
        }
    }
}
