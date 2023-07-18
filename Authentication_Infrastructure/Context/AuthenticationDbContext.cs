using Authentication_Domain.Entites;
using Authentication_Infrastructure.Configurations;
using Authentication_Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Infrastructure.Context
{
    public class AuthenticationDbContext : DbContext
    {
        private AuthenticationDbContext context;
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
            //context = new AuthenticationDbContext(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.SeedData();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
