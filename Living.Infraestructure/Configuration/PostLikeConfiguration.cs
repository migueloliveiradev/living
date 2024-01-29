using Living.Domain.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Living.Infraestructure.Configuration;
internal class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.ToTable("PostLikes")
            .HasKey(x => x.Id);

        builder.Property(x => x.PostId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Post)
            .WithMany(x => x.PostLikes)
            .HasForeignKey(x => x.PostId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.PostLikes)
            .HasForeignKey(x => x.UserId);
    }
}
