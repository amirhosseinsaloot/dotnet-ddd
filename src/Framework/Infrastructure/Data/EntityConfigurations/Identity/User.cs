using Core.Entities.Identity;

namespace Infrastructure.Data.EntityConfigurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.UserName).IsRequired().HasMaxLength(40);

        builder.Property(p => p.Firstname).IsRequired().HasMaxLength(35);

        builder.Property(p => p.Lastname).IsRequired().HasMaxLength(35);

        builder.Property(p => p.Email).IsRequired().HasMaxLength(320);

        builder.Property(p => p.IsActive).HasDefaultValue(true);

        builder.Property(p => p.Birthdate).HasColumnType("date");

        builder.Property(p => p.RefreshToken).HasMaxLength(50);

        builder.Property(p => p.RefreshTokenExpirationTime);

        builder.HasOne(p => p.Team)
               .WithMany(p => p.Users)
               .HasForeignKey(p => p.TeamId);

        builder.HasOne(p => p.ProfilePicture)
               .WithOne(p => p.User)
               .HasForeignKey<User>(p => p.ProfilePictureId);
    }
}
