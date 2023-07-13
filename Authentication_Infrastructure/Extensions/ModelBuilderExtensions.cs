using Authentication_Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "ADMIN",
                    NomalizeName = "Admin"
                },
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "USER",
                    NomalizeName = "User"
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
                    PasswordHash = "$2a$10$XD1mRo8wZ/h9aJtAD0i2yOmR3PPKb/3R4bIcwHaWu6gV5RAh3c7pG",//origin pass: Testaccount123456789_001
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
                    PasswordHash = "$2a$10$3cfpf9Kd5RWjGwIJB6acRuCJErWLuvtrrbys2OwxDJZNnRMUtGTha",//origin pass: Adminaccount123456789_001
                }
                );
            

        }
    }
}
