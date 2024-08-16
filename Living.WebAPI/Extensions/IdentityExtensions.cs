using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users.Constants;
using Living.Domain.Features.Users;
using Living.Infraestructure.Context;
using Microsoft.AspNetCore.Identity;

namespace Living.WebAPI.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddErrorDescriber<UserIdentityErrorDescriber>();

        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = UserIdentity.AllowedUserNameCharacters;
        });

        return services;
    }
}
