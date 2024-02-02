using FluentValidation;
using Living.Application.UseCases.Posts.Create;
using Living.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users;
using Living.Application.Mapping;
using Living.Domain.Entities.Users.Constants;
using Microsoft.AspNetCore.Identity;

namespace Living.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("Living"));

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

        builder.Services.AddValidatorsFromAssemblyContaining<CreatePostValidator>();

        builder.Services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(CreatePostCommand));
        });

        builder.Services.AddAuthentication().AddBearerToken();
        builder.Services.AddAuthorization();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}