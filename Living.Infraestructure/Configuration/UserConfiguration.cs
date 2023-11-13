using Living.Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Living.Infraestructure.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Posts)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.GroupUsers)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.GroupsOwned)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId);


    }

}
