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
            builder.Property(x => x.Avatar).HasMaxLength(100);
            builder.Property(x => x.LinkAvatar).HasMaxLength(100);
        }
    }
}
