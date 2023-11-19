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
            builder.Property(x => x.Avatar).HasMaxLength(200);
            builder.Property(x => x.LinkAvatar).HasMaxLength(100);
            builder.HasMany(p => p.ListMember)
                .WithMany(p => p.ListClassroom)
                .UsingEntity<MemberClassroom>(
                    l => l.HasOne/*<Member>*/(e => e.Member).WithMany(e => e.ListMemberClassroom).HasForeignKey(e => e.IdUser),
                    r => r.HasOne/*<Classroom>*/(e => e.Classroom).WithMany(e => e.ListMemberClassroom).HasForeignKey(e => e.IdClass)
                );
        }
    }
}
