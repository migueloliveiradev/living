using Living.Domain.Features.Groups;
using Living.Domain.Features.Posts;
using Living.Domain.Features.Roles;
using Living.Domain.Features.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Living.Infraestructure.Context;
public class DatabaseContext(DbContextOptions options)
    : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    public DbSet<UserSession> UserSessions => Set<UserSession>();
    public DbSet<UserFollow> UserFollows => Set<UserFollow>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostLike> PostLikes => Set<PostLike>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
