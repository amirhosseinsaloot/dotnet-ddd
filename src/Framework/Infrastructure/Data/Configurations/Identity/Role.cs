using Core.Entities.Identity;

namespace Infrastructure.Data.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(15);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
    }
}
