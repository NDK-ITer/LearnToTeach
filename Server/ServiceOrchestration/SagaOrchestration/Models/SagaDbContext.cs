using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Classrooms;
using SagaStateMachine.Classrooms.AddClassroomState;

namespace SagaOrchestration.Models
{
    public class SagaDbContext : DbContext
    {
        public SagaDbContext(DbContextOptions<SagaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassroomStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<MemberStateData>().HasKey(x => x.CorrelationId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClassroomStateData> ClassroomStateData { get; set; }
        public DbSet<MemberStateData> MemberStateData { get; set; }
    }
}
