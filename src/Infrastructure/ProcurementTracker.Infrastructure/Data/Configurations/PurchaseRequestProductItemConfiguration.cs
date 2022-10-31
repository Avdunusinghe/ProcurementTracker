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
    public class PurchaseRequestProductItemConfiguration : IEntityTypeConfiguration<PurchaseRequestProductItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequestProductItem> builder)
        {
            builder.ToTable("PurchaseRequestProductItem");

            builder.HasKey(x => x.Id);

            builder.HasOne<PurchaseRequest>(u => u.PurchaseRequest)
            .WithMany(c => c.PurchaseRequestProductItems)
            .HasForeignKey(fk => fk.PurchaseRequestId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
        }
    }
}
