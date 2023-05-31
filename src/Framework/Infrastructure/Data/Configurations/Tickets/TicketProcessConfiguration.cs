using Core.Entities.Tickets;

namespace Infrastructure.Data.Configurations.Tickets;

public class TicketProcessConfiguration : IEntityTypeConfiguration<TicketProcess>
{
    public void Configure(EntityTypeBuilder<TicketProcess> builder)
    {
        builder.HasOne(p => p.ParentTicketProcess)
               .WithMany(p => p.ChildTicketProcesses)
               .HasForeignKey(p => p.ParentTicketProcessId);

        builder.HasOne(p => p.Ticket)
               .WithMany(p => p.TicketProcesses)
               .HasForeignKey(p => p.TicketId);

        builder.HasOne(p => p.Team)
               .WithMany(p => p.TicketProcesses)
               .HasForeignKey(p => p.TeamId);

        builder.HasOne(p => p.User)
               .WithMany(p => p.TicketProcesses)
               .HasForeignKey(p => p.AssignedUserId);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(15);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
    }
}
