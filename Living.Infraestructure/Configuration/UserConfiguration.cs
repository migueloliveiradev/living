using Living.Domain.Features.Users;

namespace Living.Infraestructure.Configuration;

#pragma warning disable MA0051

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(e => e.Id);

        builder.Property(e => e.Name);

        builder.Property(e => e.Bio);

        builder.Property(e => e.Birthday);

        builder.Property(e => e.CreatedAt);

        builder.Property(e => e.LastUpdatedAt);

        builder.HasMany(e => e.Posts)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId);

        builder.HasMany(e => e.PostLikes)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UsersFollowers)
            .WithOne(e => e.Follower)
            .HasForeignKey(e => e.FollowerId);

        builder.HasMany(e => e.UsersFollowing)
            .WithOne(e => e.Following)
            .HasForeignKey(e => e.FollowingId);

        builder.HasMany(e => e.GroupsUser)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.GroupsOwned)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId);

        builder.HasMany(e => e.UserClaims)
            .WithOne(p => p.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserLogins)
            .WithOne(p => p.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserTokens)
            .WithOne(p => p.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserRoles)
            .WithOne(p => p.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserSessions)
            .WithOne(p => p.User)
            .HasForeignKey(e => e.UserId);


        builder.Ignore(e => e.NormalizedUserName);
        builder.Ignore(e => e.NormalizedEmail);
        builder.Ignore(e => e.ConcurrencyStamp);
    }
}