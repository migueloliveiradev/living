using Living.Domain.Features.Posts;

namespace Living.Infraestructure.Configuration;
internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts")
            .HasKey(x => x.Id);

        builder.Property(x => x.Content)
            .IsRequired();

        builder.Property(x => x.Access)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LastUpdatedAt)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.PostParentId)
            .IsRequired(false);

        builder.Property(x => x.PostChildId)
            .IsRequired(false);

        builder.Property(x => x.GroupId)
            .IsRequired(false);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.AuthorId);

        builder.HasMany(x => x.PostLikes)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.GroupId);

        builder.HasOne(x => x.PostChild)
            .WithMany(x => x.PostsParent)
            .HasForeignKey(x => x.PostChildId);

        builder.HasMany(x => x.PostsParent)
            .WithOne(x => x.PostChild)
            .HasForeignKey(x => x.PostChildId);

        builder.HasMany(x => x.PostsChildrens)
            .WithOne(x => x.PostParent)
            .HasForeignKey(x => x.PostParentId);

        builder.HasOne(x => x.PostParent)
            .WithMany(x => x.PostsChildrens)
            .HasForeignKey(x => x.PostParentId);
    }
}
