using Living.Infraestructure.Context;
using Living.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Living.Tests.Setup;
public class WebAPIApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.Single(
                d => d.ServiceType ==
                    typeof(DbContextOptions<DatabaseContext>));

            services.Remove(dbContextDescriptor);

            services.AddDbContext<DatabaseContext>((container, options) =>
            {
                options.UseSqlite($"Data Source=living.db");
            });
        });

        builder.UseEnvironment("Testing");

        base.ConfigureWebHost(builder);
    }
}