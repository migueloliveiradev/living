using living_backend.Config;
using living_backend.Database;
using living_backend.Hubs;
using living_backend.Repositories.Posts;
using living_backend.Repositories.Users;
using living_backend.Services.Users;
using living_backend.Shared.Policies.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace living_backend;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options => {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        builder.Services.AddSignalR();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql("Server=127.0.0.1;Database=living;Uid=root;Pwd=root;");
            options.UseLazyLoadingProxies();
        });

        builder.Services.ConfigureDependencyInjection();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("TOKEN_JWT")!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        builder.Services.AddCors(services => 
        {
            services.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
        });

        builder.Services.AddAuthorization();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors();
        
        app.MapHub<NotificationHub>("/notifications");

        app.MapControllers();

        app.Run();
    }
}