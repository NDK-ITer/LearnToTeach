using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Profile
    {
        public string? Name { get; set; }
        [NotMapped]
        public IFormFile? Avatar { get; set; }
    }
}
