using DomainDrivenDesign.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder RegisterSwaggerMidlleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(p => p.SwaggerEndpoint("/swagger/v1/swagger.json", "DomainDrivenDesign"));
        return app;
    }

    public static void IntializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

        dbContext?.Database.Migrate();

        scope.Dispose();
    }
}
