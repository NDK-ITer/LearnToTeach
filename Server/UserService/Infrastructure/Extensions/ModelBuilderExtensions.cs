using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var AdminID = Guid.NewGuid().ToString();
            var UserId = Guid.NewGuid().ToString();
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = AdminID,
                    Name = "ADMIN",
                    NomalizeName = "Admin",
                    Description = ""
                },
                new Role()
                {
                    Id = UserId,
                    Name = "USER",
                    NomalizeName = "User",
                    Description = ""
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    id = Guid.NewGuid().ToString(),
                    UserName = "testVersion_0001",
                    FirstEmail = "test001@gmail.com",
                    PresentEmail = "test001@gmail.com",
                    FirstName = "test",
                    LastName = "account",
                    IsLock = false,
                    Birthday = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    RoleId = UserId,
                    TokenAccess = string.Empty,
                    PasswordHash = PasswordMethod.HashPassword("Testaccount123456789_001"),
                },
                new User()
                {
                    id = Guid.NewGuid().ToString(),
                    UserName = "adminVersion_0001",
                    FirstEmail = "admin001@gmail.com",
                    PresentEmail = "admin001@gmail.com",
                    FirstName = "Admin",
                    LastName = "account",
                    IsLock = false,
                    Birthday = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    RoleId = AdminID,
                    TokenAccess = string.Empty,
                    PasswordHash = PasswordMethod.HashPassword("Adminaccount123456789_001"),
                }
                );
            

        }
    }
}
