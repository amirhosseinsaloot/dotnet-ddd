using Core.Entities.Identity;

namespace Infrastructure.Data.EntityConfigurations.Identity;


public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(p => p.User)
               .WithMany(p => p.UserRoles)
               .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Role)
               .WithMany(p => p.UserRoles)
               .HasForeignKey(p => p.RoleId);
    }
}
