using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class NotifyClassroomConfiguration : IEntityTypeConfiguration<NotifyClassroom>
    {
        public void Configure(EntityTypeBuilder<NotifyClassroom> builder)
        {
            builder.ToTable("NotifyClassroom");
            builder.HasKey(pk => pk.IdNotify);
            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.NameNotify).HasMaxLength(70);
            builder.Property(p => p.Description).HasMaxLength(300);
        }
    }
}
