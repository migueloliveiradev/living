using Living.Domain.Entities.Users;

namespace Living.Infraestructure.Configuration;
internal class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens")
            .HasKey(x => x.Id);

        builder.Property(x => x.LoginProvider);

        builder.Property(x => x.Name);

        builder.Property(x => x.Value);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserTokens)
            .HasForeignKey(x => x.UserId);
    }
}