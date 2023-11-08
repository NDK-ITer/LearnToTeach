using Microsoft.EntityFrameworkCore;
using SagaStateMachine.ClassroomService.Classroom.AddClassroom;
using SagaStateMachine.ClassroomService.Member;
using SagaStateMachine.ClassroomService.Member.AddMember;
using SagaStateMachine.UserService.ConfirmUserEmail;
using SagaStateMachine.UserService.ResetPassword;

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
            modelBuilder.Entity<AddMemberStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<ConfirmUserEmailStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<ResetPasswordStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<MemberModel>().HasKey(x => x.idMemberModel);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddClassroomStateData> AddClassroomStateData { get; set; }
        public DbSet<AddMemberStateData> AddMemberStateData { get; set; }
        public DbSet<ConfirmUserEmailStateData> ConfirmUserEmailStateData { get; set; }
        public DbSet<ResetPasswordStateData> ResetPasswordStateData { get; set; }
    }
}
