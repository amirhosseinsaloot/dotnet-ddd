using Core.Entities.Identity;
using Core.Entities.Teams;

namespace Core.Entities.Tickets;

public class Ticket : IBaseEntity, ICreatedOn
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TicketStatus TicketStatus { get; set; }

    public int TicketTypeId { get; set; }

    public int TeamId { get; set; }

    public int IssuerUserId { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public TicketType TicketType { get; set; } = null!;

    public Team Team { get; set; } = null!;

    public User IssuerUser { get; set; } = null!;

    public ICollection<TicketProcess>? TicketProcesses { get; set; }
}