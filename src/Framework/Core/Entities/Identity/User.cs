using Core.Entities.Files;
using Core.Entities.Logging;
using Core.Entities.Teams;
using Core.Entities.Tickets;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class User : IdentityUser<int>, IBaseEntity, ICreatedOn
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public GenderType Gender { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? LastLoginDate { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpirationTime { get; set; }

    public int TeamId { get; set; }

    public int? ProfilePictureId { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public Team Team { get; set; } = null!;

    public FileModel? ProfilePicture { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }

    public ICollection<Ticket>? Tickets { get; set; }

    public ICollection<TicketProcess>? TicketProcesses { get; set; }

    public ICollection<EmailsLog>? EmailsLogs { get; set; }
}