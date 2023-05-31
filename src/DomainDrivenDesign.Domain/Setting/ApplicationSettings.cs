namespace DomainDrivenDesign.Domain.Setting;

public sealed record class ApplicationSettings
{
    public DatabaseSettings? DatabaseSettings { get; set; }
}