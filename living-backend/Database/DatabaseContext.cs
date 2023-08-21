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
            .HasMany(e => e.Followers)
            .WithMany(e => e.Following)
            .UsingEntity<UserFollow>();

        modelBuilder.Entity<Post>()
            .Property(e => e.LikesCount)
            .HasComputedColumnSql("(SELECT COUNT(*) FROM Likes WHERE PostId = Id)");

        modelBuilder.Entity<Message>()
            .HasOne(e => e.Sender)
            .WithMany()
            .HasForeignKey(e => e.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Message>()
            .HasOne(e => e.Receiver)
            .WithMany()
            .HasForeignKey(e => e.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GroupUser>()
            .HasOne(e => e.Group)
            .WithMany()
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
