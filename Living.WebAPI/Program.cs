using Living.Application.UseCases.Users.Login;
using Living.WebAPI.Extensions;

namespace Living.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureAllOptions(builder.Configuration);

        builder.Services.AddDatabase();

        builder.Services.AddControllers();

        builder.Services.ConfigureIdentity();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddProblemDetails();

        builder.Services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(LoginUserCommand));
        });

        builder.Services.ConfigureAuthentication();
        builder.Services.AddApplication();

        builder.Services.AddCors(options => options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MigrateDatabase();

        app.UseAuthentication();

        app.UseCors();

        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}