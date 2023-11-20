using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");
            builder.HasKey(pk => new {pk.IdExercise, pk.IdMember});
            builder.Property(p => p.DateAnswer).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.LinkFile).HasMaxLength(200);
        }
    }
}
