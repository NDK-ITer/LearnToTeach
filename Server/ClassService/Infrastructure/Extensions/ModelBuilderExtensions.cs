using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var idClass_1 = Guid.NewGuid().ToString();
            var idClass_2 = Guid.NewGuid().ToString();
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = idClass_1,
                    CreateDate = DateTime.Now,
                    Name = "Class_1",
                    KeyHash = KeyHash.Hash("Class_1"),
                    IdUserHost = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                    IsPrivate = true,
                    
                },
                new Classroom
                {
                    Id = idClass_2,
                    CreateDate = DateTime.Now,
                    Name = "Class_2",
                    KeyHash = null,
                    IdUserHost = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                    IsPrivate = false,
                }
                );
            modelBuilder.Entity<MemberClassroom>().HasData(
                new MemberClassroom
                {
                    IdClass = idClass_1,
                    IdUser = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                    Name = "Admin account",
                    Avatar = string.Empty,
                    Description = string.Empty,
                    Role = string.Empty
                },
                new MemberClassroom
                {
                    IdClass = idClass_2,
                    IdUser = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                    Name = "test account",
                    Avatar = string.Empty,
                    Description = string.Empty,
                    Role = string.Empty
                }
                );
        }
    }
}
