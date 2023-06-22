using Pluralize.NET;

namespace DomainDrivenDesign.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly DatabaseSettings _databaseSettings;

    public ApplicationDbContext(IOptions<ApplicationSettings> appSettings, DbContextOptions options) : base(options)
    {
        _databaseSettings = appSettings.Value.DatabaseSettings ?? throw new Exception("Database settings can not be null, See appsettings.json");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly)
                    .HasDefaultSchema(_databaseSettings.Schema);

        IPluralize pluralizer = new Pluralizer();
        modelBuilder.ApplyNamingConventions(pluralizer);

        modelBuilder.AddDeleteBehaviorConvention(DeleteBehavior.NoAction);
    }
}
