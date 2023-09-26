using Domain.Entities;

namespace Application.Models
{
    public class UserModel
    {
        public string? id { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? role { get; set; }
        public DateTime birthday { get; set; }

        public UserModel()
        {
            
        }
        public UserModel(User user)
        {
            this.id = user.id;
            this.birthday = user.Birthday;
            this.email = user.PresentEmail;
            this.fullName = user.FirstName + " " + user.LastName;
            this.role = user.Role.Name;
            this.phoneNumber = user.PhoneNumber; 
        }
    }
}
