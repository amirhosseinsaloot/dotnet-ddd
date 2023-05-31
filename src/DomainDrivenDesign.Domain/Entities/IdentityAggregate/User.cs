using DomainDrivenDesign.Domain.Entities.TeamAggregate;

namespace DomainDrivenDesign.Domain.Entities.IdentityAggregate;

public class User : IdentityUser<long>, IAggregateRoot, ICreatedOn
{
    public User(string userName, string firstname, string lastname, DateTime birthdate,
        GenderType gender, bool isActive, DateTime? lastLoginDate, string? refreshToken,
        DateTime? refreshTokenExpirationTime, long teamId, DateTime createdOn) : base(userName)
    {
        Firstname = firstname;
        Lastname = lastname;
        Birthdate = birthdate;
        Gender = gender;
        IsActive = isActive;
        LastLoginDate = lastLoginDate;
        RefreshToken = refreshToken;
        RefreshTokenExpirationTime = refreshTokenExpirationTime;
        TeamId = teamId;
        CreatedOn = createdOn;
    }

    public string Firstname { get; private set; }

    public string Lastname { get; private set; }

    public DateTime Birthdate { get; private set; }

    public GenderType Gender { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime? LastLoginDate { get; private set; }

    public string? RefreshToken { get; private set; }

    public DateTime? RefreshTokenExpirationTime { get; private set; }

    public long TeamId { get; private set; }

    public Team Team { get; private set; } = null!;

    public DateTime CreatedOn { get; private set; }

    // DDD Patterns comment from eShopOnWeb
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so collection items cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the domain method which includes behavior.
    private readonly List<UserRole> _userRoles = null!;
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();
}
