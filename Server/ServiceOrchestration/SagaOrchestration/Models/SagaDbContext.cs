using Microsoft.EntityFrameworkCore;
using SagaStateMachine.ClassroomService.Classroom;
using SagaStateMachine.ClassroomService.Member;
using SagaStateMachine.UserService;

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
            modelBuilder.Entity<UserStateData>().HasKey(x => x.CorrelationId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClassroomStateData> ClassroomStateData { get; set; }
        public DbSet<MemberStateData> MemberStateData { get; set; }
        public DbSet<UserStateData> UserStateData { get; set; }
    }
}
