using Living.Domain.Features.Roles;
using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Constants;
using Living.Infraestructure.Context;
using Living.Infraestructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Living.WebAPI.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddErrorDescriber<UserIdentityErrorDescriber>()
                .AddUserManager<LivingUserManager>();

        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = UserIdentity.ALLOWED_USER_NAME_CHARACTERS;
            options.ClaimsIdentity.UserIdClaimType = UserClaimsTokens.USER_ID;
        });

        return services;
    }
}
