using DomainDrivenDesign.Domain.Entities.IdentityAggregate;

namespace DomainDrivenDesign.Infrastructure.Data.EntityConfigurations.IdentityAggregate;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.UserName).IsRequired().HasMaxLength(40);

        builder.Property(p => p.Firstname).IsRequired().HasMaxLength(35);

        builder.Property(p => p.Lastname).IsRequired().HasMaxLength(35);

        builder.Property(p => p.Email).IsRequired().HasMaxLength(320);

        builder.Property(p => p.Birthdate).HasColumnType("date");

        builder.Property(p => p.RefreshToken).HasMaxLength(50);

        builder.Property(p => p.RefreshTokenExpirationTime);

        // Team relation:
        builder.HasOne(p => p.Team)
            .WithMany()
            .HasForeignKey(p => p.TeamId);
    }
}
