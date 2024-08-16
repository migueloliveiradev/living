using Living.Domain.Features.Roles;

namespace Living.Infraestructure.Configuration;
internal sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaims")
            .HasKey(rc => rc.Id);

        builder.Property(rc => rc.ClaimType);

        builder.Property(rc => rc.ClaimValue);

        builder.HasOne(rc => rc.Role)
            .WithMany(r => r.RoleClaims)
            .HasForeignKey(rc => rc.RoleId);
    }
}
