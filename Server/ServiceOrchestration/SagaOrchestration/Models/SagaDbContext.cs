using Microsoft.EntityFrameworkCore;
using SagaStateMachine.ClassroomService.Classroom;
using SagaStateMachine.ClassroomService.Member;
using SagaStateMachine.UserService.ConfirmUserEmail;

namespace SagaOrchestration.Models
{
    public class SagaDbContext : DbContext
    {
        public SagaDbContext(DbContextOptions<SagaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddClassroomStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<MemberStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<ConfirmUserEmailStateData>().HasKey(x => x.CorrelationId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddClassroomStateData> AddClassroomStateData { get; set; }
        public DbSet<MemberStateData> MemberStateData { get; set; }
        public DbSet<ConfirmUserEmailStateData> ConfirmUserEmailStateData { get; set; }
    }
}
