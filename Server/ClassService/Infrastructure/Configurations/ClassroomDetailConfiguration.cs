using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ClassroomDetailConfiguration : IEntityTypeConfiguration<ClassroomDetail>
    {
        public void Configure(EntityTypeBuilder<ClassroomDetail> builder)
        {
            builder.ToTable("ClassroomDetails");
            builder.HasKey(x => new { x.IdUser, x.IdClass });
            builder.Property(x => x.IdUser).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdClass).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Avatar).HasMaxLength(100);
            builder.HasOne<Classroom>(c => c.classroom)
                .WithMany(cd => cd.ListUserId)
                .HasForeignKey(fk => fk.IdClass);
        }
    }
}
