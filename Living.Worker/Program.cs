using Living.Infraestructure.Extensions;
using Living.Worker.Extensions;

namespace Living.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddApplication();

        builder.Services.AddOptionsConfiguration(builder.Configuration);

        builder.Services.AddDatabase();
        builder.Services.AddMessagingConfiguration();

        var host = builder.Build();
        host.Run();
    }
}