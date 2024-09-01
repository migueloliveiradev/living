using Living.Application.UseCases.Users.Login;
using Living.WebAPI.ExceptionsHandler;
using Living.WebAPI.Extensions;
using System.Text.Json.Serialization;

namespace Living.WebAPI;
public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOptionsConfiguration(builder.Configuration);

        builder.Services.AddDatabase();

        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            .AddInvalidModelStateConfiguration();

        builder.Services.AddIdentityConfiguration();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddProblemDetails();

        builder.Services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(LoginUserCommand));
        });

        builder.Services.AddAuthenticationConfiguration();
        builder.Services.AddApplication();

        builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();

        builder.Services.AddCors(options => options.AddDefaultPolicy(
            cors => cors.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseDatabase();

        app.UseAuthentication();

        app.UseCors();

        app.UseExceptionHandler();
        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}