using Living.Infraestructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Living.Tests.Setup;
public class WebAPIApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ServiceDescriptor dbContextDescriptor = services.Single(
                d => d.ServiceType ==
                    typeof(DbContextOptions<DatabaseContext>));

            services.Remove(dbContextDescriptor);

            services.AddDbContext<DatabaseContext>((container, options) =>
            {
                options.UseSqlite("DataSource=:memory:");
            });
        });
    }
}