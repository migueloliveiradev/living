using FluentValidation;
using Living.Application.UseCases.Posts.Create;
using Microsoft.EntityFrameworkCore;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users;
using Living.Application.Mapping;
using Living.Domain.Entities.Users.Constants;
using Microsoft.AspNetCore.Identity;
using Living.Infraestructure.Context;
using Living.Infraestructure.Context.Interceptors;
using Living.Application.UseCases.Users.Login;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Living.WebAPI.ExceptionsHandler;
using Living.WebAPI.Extensions;

namespace Living.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.AddInterceptors(new TimestampsInterceptor());
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
        });

        builder.Services.AddControllers();

        builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddErrorDescriber<UserIdentityErrorDescriber>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ._1234567890";
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(BaseProfile));

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