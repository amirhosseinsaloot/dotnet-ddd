namespace Infrastructure.Data.EntityConfigurations.Teams;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);

        builder.HasOne(p => p.ParentTeam)
               .WithMany(p => p.ChildTeams)
               .HasForeignKey(p => p.ParentId);

        builder.HasOne(p => p.Tenant)
               .WithMany(p => p.Teams)
               .HasForeignKey(p => p.TenantId);
    }
}

