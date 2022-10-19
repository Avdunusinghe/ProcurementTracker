﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Price)
                .HasPrecision(14, 2);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(c => c.CreatedProducts)
               .HasForeignKey(fk => fk.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.UpdatedBy)
               .WithMany(c => c.UpdatedProducts)
               .HasForeignKey(fk => fk.LastUpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);
        }
    }
}