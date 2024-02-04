using Living.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Living.Infraestructure.Configuration;
internal class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
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
