using Authentication_Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication_Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).HasMaxLength(200);
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Birthday).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.FirstEmail).IsRequired(true).HasMaxLength(70);
            builder.Property(x => x.PresentEmail).IsRequired(true).HasMaxLength(70);
            builder.Property(x => x.PasswordHash).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.RoleId).HasMaxLength(200);
            builder.HasOne<Role>(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(fk => fk.RoleId);
        }
    }
}
