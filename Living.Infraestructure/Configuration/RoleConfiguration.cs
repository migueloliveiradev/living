using Living.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Living.Infraestructure.Configuration;
internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles")
            .HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.Role)
            .HasForeignKey(e => e.RoleId);
    }
}
