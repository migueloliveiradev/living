using Living.Domain.Features.Users;

namespace Living.Infraestructure.Configuration;
internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LoginProvider);

        builder.Property(x => x.ProviderKey);

        builder.Property(x => x.ProviderDisplayName);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserLogins)
            .HasForeignKey(x => x.UserId);
    }
}