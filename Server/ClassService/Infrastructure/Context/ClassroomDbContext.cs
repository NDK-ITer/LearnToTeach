using Domain.Entities;
using Infrastructure.Configurations;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ClassroomDbContext : DbContext
    {
        public ClassroomDbContext(DbContextOptions<ClassroomDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomDetailConfiguration());
            modelBuilder.SeedData();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<MemberClassroom> MemberClassrooms { get; set; }
    }
}
