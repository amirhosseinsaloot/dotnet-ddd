using Core.Entities.Identity;
using Core.Entities.Tickets;

namespace Core.Entities.Teams;

public class Team : IBaseEntity, ICreatedOn
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ParentId { get; set; }

    public int? TenantId { get; set; }

    public DateTime CreatedOn { get; set; }


    // Navigation properties
    public Team? ParentTeam { get; set; }

    public Tenant? Tenant { get; set; }

    public ICollection<Team>? ChildTeams { get; set; }

    public ICollection<Ticket>? Tickets { get; set; }

    public ICollection<TicketProcess>? TicketProcesses { get; set; }

    public ICollection<User>? Users { get; set; }
}