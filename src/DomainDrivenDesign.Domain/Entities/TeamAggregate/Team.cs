namespace DomainDrivenDesign.Domain.Entities.TeamAggregate;

public class Team : BaseEntity<long>, IAggregateRoot, ICreatedOn
{
    public Team(string name, string description, long? parentTeamId)
    {
        Name = name;
        Description = description;
        ParentTeamId = parentTeamId;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public long? ParentTeamId { get; private set; }

    public Team? ParentTeam { get; private set; }

    // DDD Patterns comment from eShopOnWeb
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so collection items cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the domain method which includes behavior.

    private readonly List<Team> _childTeams = null!;

    public IReadOnlyCollection<Team> ChildTeams => _childTeams.AsReadOnly();

    public DateTime CreatedOn { get; private set; }
}
