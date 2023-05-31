using DomainDrivenDesign.Domain.Entities.IdentityAggregate;

namespace DomainDrivenDesign.Infrastructure.Data.EntityConfigurations.IdentityAggregate;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(15);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
    }
}
