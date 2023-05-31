using DomainDrivenDesign.Domain.Entities.IdentityAggregate;

namespace DomainDrivenDesign.Infrastructure.Data.EntityConfigurations.IdentityAggregate;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(p => new { p.UserId, p.RoleId });

        // User relation:
        var userNavigation = builder.Metadata.FindNavigation(nameof(UserRole.User));
        userNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasOne(p => p.User)
               .WithMany(p => p.UserRoles)
               .HasForeignKey(p => p.UserId);
        
        // Role relation:
        var roleNavigation = builder.Metadata.FindNavigation(nameof(UserRole.User));
        roleNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.HasOne(p => p.Role)
               .WithMany(p => p.UserRoles)
               .HasForeignKey(p => p.RoleId);
    }
}
