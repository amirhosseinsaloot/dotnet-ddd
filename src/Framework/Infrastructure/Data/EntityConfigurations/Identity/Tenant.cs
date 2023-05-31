using Core.Entities.Identity;

namespace Infrastructure.Data.EntityConfigurations.Identity;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(p => p.Name).IsUnique();
    }
}
