namespace DomainDrivenDesign.Domain.Entities.IdentityAggregate;

public class UserRole : IdentityUserRole<long>, ICreatedOn
{
    public DateTime CreatedOn { get; private set; }

    public User User { get; private set; } = null!;

    public Role Role { get; private set; } = null!;
}
