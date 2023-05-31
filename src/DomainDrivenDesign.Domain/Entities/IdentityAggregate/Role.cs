namespace DomainDrivenDesign.Domain.Entities.IdentityAggregate;

public class Role : IdentityRole<long>, ICreatedOn
{
    public Role(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }

    public DateTime CreatedOn { get; private set; }


    // DDD Patterns comment from eShopOnWeb
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so collection items cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the domain method which includes behavior.
    private readonly List<UserRole> _userRoles = null!;
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();
}
