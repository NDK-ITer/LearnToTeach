using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LearningDocumentConfiguration : IEntityTypeConfiguration<LearningDocument>
    {
        public void Configure(EntityTypeBuilder<LearningDocument> builder)
        {
            builder.ToTable("LearningDocument");
            builder.HasKey(pk => pk.NameFile);
            builder.Property(p => p.LinkFile).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(200);
        }
    }
}
