using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(200);
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.NomalizeName).HasMaxLength(20);
        }
    }
}
