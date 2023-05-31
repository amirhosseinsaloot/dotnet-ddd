using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Infrastructure.Data;
using DomainDrivenDesign.Infrastructure.Data.Repository;
using DomainDrivenDesign.Infrastructure.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DomainDrivenDesign.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "V1" });
        });
    }

    public static void AddDbContext(this IServiceCollection services, DatabaseSettings? databaseSettings)
    {
        ArgumentNullException.ThrowIfNull(databaseSettings);

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(databaseSettings.ConnectionString,
                options => options.MigrationsHistoryTable("__EFMigrationsHistory", databaseSettings.Schema));
        });
    }

    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ApplicationSettings>()
            .Bind(configuration);
    }

    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}
