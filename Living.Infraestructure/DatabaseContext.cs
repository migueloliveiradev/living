using Living.Domain.Entities.Groups;
using Living.Domain.Entities.Posts;
using Living.Domain.Entities.Roles;
using Living.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Living.Infraestructure;
public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<UserFollow> UserFollows => Set<UserFollow>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostLike> PostLikes => Set<PostLike>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Living");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
