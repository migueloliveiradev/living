using living_backend.Models.Groups;
using living_backend.Models.Messages;
using living_backend.Models.Posts;
using living_backend.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace living_backend.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserFollow> UserFollows { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Groups)
            .UsingEntity<GroupUser>();

        modelBuilder.Entity<User>()
            .HasMany(e => e.GroupsOwned)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
           .HasMany(u => u.Followers)
           .WithMany()
           .UsingEntity<UserFollow>();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Following)
            .WithMany()
            .UsingEntity<UserFollow>();

        modelBuilder.Entity<UserFollow>()
            .HasOne(uf => uf.Follower)
            .WithMany()
            .HasForeignKey(uf => uf.FollowerId)
            .HasPrincipalKey(u => u.Id);

        modelBuilder.Entity<UserFollow>()
            .HasOne(uf => uf.Following)
            .WithMany()
            .HasForeignKey(uf => uf.FollowingId)
            .HasPrincipalKey(u => u.Id);

        modelBuilder.Entity<Post>()
            .Property(p => p.GroupId)
            .IsRequired(false);

    }
}
