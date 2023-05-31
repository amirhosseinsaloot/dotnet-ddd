using Core.Entities.Tickets;

namespace Infrastructure.Data.EntityConfigurations.Tickets;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(p => p.Team)
               .WithMany(p => p.Tickets)
               .HasForeignKey(p => p.TeamId);

        builder.HasOne(p => p.TicketType)
               .WithMany(p => p.Tickets)
               .HasForeignKey(p => p.TicketTypeId);

        builder.HasOne(p => p.IssuerUser)
               .WithMany(p => p.Tickets)
               .HasForeignKey(p => p.IssuerUserId);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(30);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);

        builder.Property(p => p.TicketStatus).IsRequired();
    }
}
