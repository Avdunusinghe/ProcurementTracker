using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
