using Living.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Living.WebAPI.Extensions;

public static class DatabaseContextExtensions
{
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();

        return app;
    }
}
