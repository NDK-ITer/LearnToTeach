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
                    IdUserHost = "9d853125-0a15-40ee-bbc1-ee25fbdbacc1",
                    IsPrivate = true,
                    
                },
                new Classroom
                {
                    Id = idClass_2,
                    CreateDate = DateTime.Now,
                    Name = "Class_2",
                    KeyHash = null,
                    IdUserHost = "9d853125-0a15-40ee-bbc1-ee25fbdbacc1",
                    IsPrivate = false,
                }
                );
            modelBuilder.Entity<ClassroomDetail>().HasData(
                new ClassroomDetail
                {
                    IdClass = idClass_1,
                    IdUser = "c40aa1e2-8625-4974-a0b3-ae9e75485ea3",
                    Description = string.Empty,
                    Role = string.Empty
                },
                new ClassroomDetail
                {
                    IdClass = idClass_2,
                    IdUser = "c40aa1e2-8625-4974-a0b3-ae9e75485ea3",
                    Description = string.Empty,
                    Role = string.Empty
                }
                );
        }
    }
}
