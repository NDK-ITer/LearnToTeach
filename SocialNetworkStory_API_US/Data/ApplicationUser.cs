using Microsoft.AspNetCore.Identity;

namespace MyDemoAPIAsp.NETCore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
