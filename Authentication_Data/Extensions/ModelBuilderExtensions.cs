using Authentication_Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { id = Guid.NewGuid().ToString(), Name = "ADMIN", Description = "", NormalizeName = "Admin" },
                new Role() { id = Guid.NewGuid().ToString(), Name = "MANAGER", Description = "", NormalizeName = "Manager" },
                new Role() { id = Guid.NewGuid().ToString(), Name = "USER", Description = "", NormalizeName = "User" }
                );
            
        }
    }
}
