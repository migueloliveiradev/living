using Living.Domain.Features.Users;

namespace Living.Infraestructure.Configuration;
internal sealed class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("UserSessions")
            .HasKey(x => x.Id);

        builder.Property(x => x.RefreshToken);

        builder.Property(x => x.CreatedAt);

        builder.Property(x => x.LastUpdatedAt);

        builder.HasOne(x => x.User)
            .WithMany(p => p.UserSessions)
            .HasForeignKey(x => x.UserId);
    }
}
