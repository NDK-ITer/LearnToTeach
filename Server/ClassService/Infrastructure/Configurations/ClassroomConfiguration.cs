using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("Classrooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.IsPrivate).IsRequired();
            builder.Property(x => x.KeyHash).HasMaxLength(200);
            builder.Property(x => x.NameUserHost).HasMaxLength(50);
            builder.Property(x => x.AvatarUserHost).HasMaxLength(100);
        }
    }
}
