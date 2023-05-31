using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class Role : IdentityRole<int>, IBaseEntity, ICreatedOn
{
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    // Navigation Properties
    public ICollection<UserRole>? UserRoles { get; set; }
}