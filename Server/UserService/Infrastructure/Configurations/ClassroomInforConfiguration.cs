using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ClassroomInforConfiguration : IEntityTypeConfiguration<ClassroomInfor>
    {
        public void Configure(EntityTypeBuilder<ClassroomInfor> builder)
        {
            builder.ToTable("ClassroomInfor");
            builder.HasKey(x => new {x.IdUser, x.IdClassroom});
            builder.Property(x => x.IdUser).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdClassroom).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Avatar).HasMaxLength(200);
            builder.Property(x => x.LinkAvatar).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.HasOne<User>(c => c.User)
                .WithMany(c => c.ListClassroomInfor)
                .HasForeignKey(fk => fk.IdUser);
        }
    }
}
