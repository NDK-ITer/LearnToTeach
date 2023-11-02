using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                    IdUserHost = "1",
                    IsPrivate = true,
                    
                },
                new Classroom
                {
                    Id = idClass_2,
                    CreateDate = DateTime.Now,
                    Name = "Class_2",
                    KeyHash = null,
                    IdUserHost = "1",
                    IsPrivate = false,
                }
                );
            modelBuilder.Entity<ClassroomDetail>().HasData(
                new ClassroomDetail
                {
                    IdClass = idClass_1,
                    IdUser = "1",
                    Name = string.Empty,
                    Avatar = string.Empty,
                    Description = string.Empty,
                    Role = string.Empty
                },
                new ClassroomDetail
                {
                    IdClass = idClass_2,
                    IdUser = "2",
                    Name = string.Empty,
                    Avatar = string.Empty,
                    Description = string.Empty,
                    Role = string.Empty
                }
                );
        }
    }
}
