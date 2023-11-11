using Microsoft.EntityFrameworkCore;
using SagaStateMachine.ClassroomService.Classroom;
using SagaStateMachine.ClassroomService.Member;
using SagaStateMachine.UserService.ConfirmUserEmail;
using SagaStateMachine.UserService.ResetPassword;
using SagaStateMachine.UserService.UpdateUserInfor;

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
            modelBuilder.Entity<ConfirmUserEmailStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<ResetPasswordStateData>().HasKey(x => x.CorrelationId);
            modelBuilder.Entity<UpdateUserInforStateData>().HasKey(x => x.CorrelationId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClassroomStateData> ClassroomStateData { get; set; }
        public DbSet<MemberStateData> MemberStateData { get; set; }
        public DbSet<ConfirmUserEmailStateData> ConfirmUserEmailStateData { get; set; }
        public DbSet<ResetPasswordStateData> ResetPasswordStateData { get; set; }
        public DbSet<UpdateUserInforStateData> UpdateUserInforStateData { get; set; }
    }
}
