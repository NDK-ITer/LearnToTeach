using Domain.Entities;
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
                    NormalizeName = "Admin",
                    Description = ""
                },
                new Role()
                {
                    Id = UserId,
                    Name = "USER",
                    NormalizeName = "User",
                    Description = ""
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    id = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                    UserName = "testVersion_0001",
                    FirstEmail = "test001@gmail.com",
                    PresentEmail = "test001@gmail.com",
                    FirstName = "test",
                    LastName = "account",
                    IsLock = false,
                    Birthday = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    RoleId = UserId,
                    TokenAccess = SecurityMethods.CreateRandomToken(),
                    VerifiedDate = DateTime.Now,
                    IsVerified = true,
                    PhoneNumber = "0123456789",
                    Avatar = "",
                    PasswordHash = SecurityMethods.HashPassword("Testaccount123456789_001"),
                },
                new User()
                {
                    id = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                    UserName = "adminVersion_0001",
                    FirstEmail = "admin001@gmail.com",
                    PresentEmail = "admin001@gmail.com",
                    FirstName = "Admin",
                    LastName = "account",
                    IsLock = false,
                    Birthday = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    RoleId = AdminID,
                    TokenAccess = SecurityMethods.CreateRandomToken(),
                    VerifiedDate = DateTime.Now,
                    IsVerified = true,
                    PhoneNumber = "0123456789",
                    Avatar = "",
                    PasswordHash = SecurityMethods.HashPassword("Adminaccount123456789_001"),
                }
                );
            modelBuilder.Entity<ClassroomInfor>().HasData(
                new ClassroomInfor()
                {
                    IdClassroom = "ee546ce7-842a-4dee-86d0-0db1ff3b64b4",
                    IdUser = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                    Name = "Class_1",
                    Description = "",
                    IsHost = true,
                },
                new ClassroomInfor()
                {
                    IdClassroom = "0a006921-b4a4-40de-a1e6-9497daf09a2f",
                    IdUser = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                    Name = "Class_2",
                    Description = "",
                    IsHost = true,
                }
                );


        }
    }
}
