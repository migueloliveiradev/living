using FluentValidation;
using Living.Application.UseCases.Posts.Create;
using Living.Application.UseCases.Users.Login;
using Living.WebAPI.ExceptionsHandler;
using Living.WebAPI.Extensions;
using MediatR.Extensions.FluentValidation.AspNetCore;

namespace Living.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDatabase(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.ConfigureIdentity();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddValidatorsFromAssemblyContaining<LoginUserCommand>();

        builder.Services.AddFluentValidation([typeof(LoginUserCommand).Assembly]);

        builder.Services.AddExceptionHandler<FluentValidationExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(CreatePostCommand));
        });

        builder.Services.AddAuthentication().AddBearerToken();
        builder.Services.AddAuthorization();

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