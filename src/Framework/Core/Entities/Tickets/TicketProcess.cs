using Core.Entities.Identity;
using Core.Entities.Teams;

namespace Core.Entities.Tickets;

public class TicketProcess : IBaseEntity, ICreatedOn
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int TicketId { get; set; }

    public int TeamId { get; set; }

    public int? AssignedUserId { get; set; }

    public int? ParentTicketProcessId { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public TicketProcess? ParentTicketProcess { get; set; }

    public ICollection<TicketProcess>? ChildTicketProcesses { get; set; }

    public Ticket Ticket { get; set; } = null!;

    public Team Team { get; set; } = null!;

    public User? User { get; set; }
}