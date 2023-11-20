using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MemberClassroomConfiguration : IEntityTypeConfiguration<MemberClassroom>
    {
        public void Configure(EntityTypeBuilder<MemberClassroom> builder)
        {
            builder.ToTable("MemberClassroom");
            builder.HasKey(x => new { x.IdUser, x.IdClass });
            builder.Property(x => x.IdUser).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdClass).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(100);
        }
    }
}
