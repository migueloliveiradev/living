using Living.Domain.Features.Groups;

namespace Living.Infraestructure.Configuration;
internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups")
            .HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(g => g.CreatedAt)
            .ValueGeneratedOnAdd();

        builder.Property(g => g.LastUpdatedAt)
            .ValueGeneratedOnUpdate();

        builder.HasOne(g => g.Owner)
            .WithMany(u => u.GroupsOwned)
            .HasForeignKey(g => g.OwnerId);

        builder.HasMany(g => g.Posts)
            .WithOne(p => p.Group)
            .HasForeignKey(p => p.GroupId);

        builder.HasMany(g => g.GroupUsers)
            .WithOne(gu => gu.Group)
            .HasForeignKey(gu => gu.GroupId);
    }
}
