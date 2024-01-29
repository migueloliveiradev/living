using Living.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Living.Infraestructure.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Bio)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(e => e.Birthday)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.LastUpdatedAt)
            .IsRequired(false);

        builder.Property(e => e.DeletedAt)
            .IsRequired(false);

        builder.HasMany(e => e.Posts)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId);

        builder.HasMany(e => e.PostLikes)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UsersFollowers)
            .WithOne(e => e.Following)
            .HasForeignKey(e => e.FollowingId);

        builder.HasMany(e => e.UsersFollowing)
            .WithOne(e => e.Follower)
            .HasForeignKey(e => e.FollowerId);

        builder.HasMany(e => e.GroupsUser)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.GroupsOwned)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId);

        builder.HasMany(e => e.Claims)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Logins)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Tokens)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasIndex(e => e.Name);
    }
}