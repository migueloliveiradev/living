using Living.Domain.Base;
using Living.Domain.Features.Users.Constants;
using Living.Infraestructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace Living.WebAPI.Extensions;

public static class AuthExtensions
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services)
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
            options.Events = new()
            {
                OnMessageReceived = context =>
                {
                    if (context.Request.Cookies.TryGetValue(UserCookies.ACCESS_TOKEN, out var token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception is SecurityTokenExpiredException)
                    {
                        context.Response.Headers.Append("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                },
                OnChallenge = async context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsJsonAsync(new BaseResponse(UserErrors.NOT_AUTHORIZED, HttpStatusCode.Unauthorized), context.HttpContext.RequestAborted);
                }
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
