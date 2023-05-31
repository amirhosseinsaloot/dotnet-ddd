using DomainDrivenDesign.Domain.Entities.TeamAggregate;

namespace DomainDrivenDesign.Infrastructure.Data.EntityConfigurations.TeamAggregate;

public class TeamConfigurations : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);

        // Parent team relation:
        builder.HasOne(p => p.ParentTeam)
               .WithMany(p => p.ChildTeams)
               .HasForeignKey(p => p.ParentTeamId);
    }
}
