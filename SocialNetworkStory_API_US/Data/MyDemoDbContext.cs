using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyDemoAPIAsp.NETCore.Data
{
    public class MyDemoDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDemoDbContext (DbContextOptions<MyDemoDbContext> opt ): base(opt) 
        { 
        }
    }
}
