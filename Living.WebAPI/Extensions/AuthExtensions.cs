using Living.Domain.Features.Users.Constants;
using Living.Infraestructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Living.WebAPI.Extensions;

public static class AuthExtensions
{
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var settings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Issuer,
                ValidAudience = settings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret)),
            };
            options.SaveToken = true;
            options.Events = new();
            options.Events.OnMessageReceived = context =>
            {
                if (context.Request.Cookies.TryGetValue(UserCookies.ACCESS_TOKEN, out var token))
                {
                    context.Token = token;
                }

                return Task.CompletedTask;
            };
        })
        .AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });

        services.AddAuthorization();
    }
}
