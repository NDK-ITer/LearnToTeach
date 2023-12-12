using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(x => x.IdMember);
            builder.Property(x => x.IdMember).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Avatar).HasMaxLength(100);
            builder.Property(x => x.LinkAvatar).HasMaxLength(100);
            builder.HasMany(p => p.ListExercise)
                .WithMany(p => p.ListMember)
                .UsingEntity<Answer>(
                    l => l.HasOne(e => e.Exercise).WithMany(e => e.ListAnswer).HasForeignKey(e => e.IdExercise),
                    r => r.HasOne(e => e.Member).WithMany(e => e.ListAnswer).HasForeignKey(e => e.IdMember)
                );
        }
    }
}
