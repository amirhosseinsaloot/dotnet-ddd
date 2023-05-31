using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class UserRole : IdentityUserRole<int>, IEntity, ICreatedOn
{
    public DateTime CreatedOn { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}