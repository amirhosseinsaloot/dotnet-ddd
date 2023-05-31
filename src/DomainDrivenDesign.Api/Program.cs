using CorrelationId;
using CorrelationId.DependencyInjection;
using DomainDrivenDesign.Api;
using DomainDrivenDesign.Api.Extensions;
using DomainDrivenDesign.Api.Middlewares;
using DomainDrivenDesign.Domain.Setting;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

var databaseSettings = configuration
    .GetSection("DatabaseSettings")
    .Get<DatabaseSettings>();

// Add services to the container.
ConfigureServices(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigurePipeline(app);

app.Run();


void ConfigureServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddDbContext(databaseSettings);
    serviceCollection.RegisterDependencies();
    serviceCollection.ConfigureSettings(configuration);
    serviceCollection.AddSwagger();
    serviceCollection.AddMvc();
    serviceCollection.AddControllers();
    serviceCollection.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters()
        .AddValidatorsFromAssemblyContaining(typeof(CustomAbstractValidator<>));
    serviceCollection.AddDefaultCorrelationId(options =>
    {
        options.AddToLoggingScope = true;
        options.CorrelationIdGenerator = () => Guid.NewGuid().ToString();
    });
}

void ConfigurePipeline(IApplicationBuilder applicationBuilder)
{
    applicationBuilder.UseCorrelationId();
    applicationBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    applicationBuilder.UseRouting();
    applicationBuilder.UseMiddleware<RequestResponseLoggingMiddleware>();
    applicationBuilder.IntializeDatabase();
    applicationBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    applicationBuilder.RegisterSwaggerMidlleware();
}


// Make the implicit Program class public so test projects can access it
namespace DomainDrivenDesign.Api
{
    public partial class Program
    {
    }
}
