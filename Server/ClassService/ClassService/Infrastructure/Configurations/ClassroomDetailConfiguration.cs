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
            builder.HasOne(x => x.classroom)
                .WithMany(x => x.ListUserId)
                .HasForeignKey(x => x.IdClass);
        }
    }
}
