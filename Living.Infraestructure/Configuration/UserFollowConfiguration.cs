using Living.Domain.Features.Users;

namespace Living.Infraestructure.Configuration;
internal sealed class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {
        builder.ToTable("UserFollows")
            .HasKey(x => x.Id);

        builder.HasOne(x => x.Follower)
            .WithMany(x => x.UsersFollowers)
            .HasForeignKey(x => x.FollowerId);

        builder.HasOne(x => x.Following)
            .WithMany(x => x.UsersFollowing)
            .HasForeignKey(x => x.FollowingId);
    }
}
