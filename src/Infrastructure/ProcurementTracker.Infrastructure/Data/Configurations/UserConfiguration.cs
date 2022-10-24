using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(t => t.Id);

            builder
               .HasOne<Role>(a => a.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(a => a.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne<User>(a => a.CreatedBy)
               .WithMany(r => r.CreatedUsers)
               .HasForeignKey(a => a.CreatedById)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(a => a.LastUpdatedBy)
                .WithMany(r => r.UpdatedUsers)
                .HasForeignKey(a => a.LastUpdatedById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
