using FluentValidation;
using Living.Application.UseCases.Posts.Create;
using Living.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users;

namespace Living.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("Living"));

        builder.Services.AddControllers();

        builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddApiEndpoints();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(configuration =>
        {
            //configuration.AddBehavior(typeof(ValidationBehavior<>));
            configuration.RegisterServicesFromAssemblyContaining(typeof(CreatePostCommand));
        });

        builder.Services.AddValidatorsFromAssemblyContaining<CreatePostValidator>();


        builder.Services.AddAuthentication().AddBearerToken();
        builder.Services.AddAuthorization();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
