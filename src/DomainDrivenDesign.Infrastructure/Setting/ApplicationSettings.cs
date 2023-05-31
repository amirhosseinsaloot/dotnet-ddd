namespace DomainDrivenDesign.Infrastructure.Setting;

public sealed record class ApplicationSettings
{
    public DatabaseSettings? DatabaseSettings { get; set; }
}