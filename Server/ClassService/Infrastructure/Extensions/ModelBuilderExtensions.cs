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
                    Id = "d0186509-69d2-4a76-a0d1-69c5916c0b02",
                    CreateDate = DateTime.Now,
                    Name = "Class_1",
                    KeyHash = KeyHash.Hash("Class_1"),
                    Avatar = string.Empty,
                    LinkAvatar = string.Empty,
                    IsPrivate = true,
                    
                },
                new Classroom
                {
                    Id = "02c47002-cc29-4b66-82bd-a86b7e3c6d5e",
                    CreateDate = DateTime.Now,
                    Name = "Class_2",
                    KeyHash = null,
                    Avatar = string.Empty,
                    LinkAvatar = string.Empty,
                    IsPrivate = false,
                }
                );
            //modelBuilder.Entity<MemberClassroom>().HasData(
            //    new MemberClassroom
            //    {
            //        IdClass = "d0186509-69d2-4a76-a0d1-69c5916c0b02",
            //        IdUser = "2c75293b-f8e5-4862-9b13-5894a64895cd",
            //        Name = "Admin account",
            //        Avatar = string.Empty,
            //        LinkAvatar = string.Empty,
            //        Description = string.Empty,
            //        Role = "MEMBER"
            //    },
            //    new MemberClassroom
            //    {
            //        IdClass = "02c47002-cc29-4b66-82bd-a86b7e3c6d5e",
            //        IdUser = "193ba283-bf34-40ad-a3be-10b1780cba0e",
            //        Name = "test account",
            //        Avatar = string.Empty,
            //        LinkAvatar = string.Empty,
            //        Description = string.Empty,
            //        Role = "MEMBER"
            //    }
            //    );
        }
    }
}
