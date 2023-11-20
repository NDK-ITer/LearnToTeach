using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercise");
            builder.HasKey(x => x.IdExercise);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.LinkFile).HasMaxLength(200);
            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
            builder.HasMany(p => p.ListAnswer)
                .WithOne(p => p.Exercise)
                .HasForeignKey(p => p.IdExercise);
        }
    }
}
