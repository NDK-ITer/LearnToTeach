using Domain.Entities;
using XAct;

namespace Application.Models
{
    public class UserModel
    {
        public string? id { get; set; }
        public string? fullName { get; set; }
        public string? lastName { get; set; }
        public string? firstName { get; set; }
        public DateTime? createDate { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? role { get; set; }
        public string? avatar { get; set; }
        public DateTime birthday { get; set; }
        public List<ClassroomInforModel> listClassroom { get; set; }

        public UserModel()
        {
            
        }
        public UserModel(User user)
        {
            listClassroom = new List<ClassroomInforModel>();
            this.id = user.id;
            this.birthday = user.Birthday;
            this.email = user.PresentEmail;
            this.fullName = user.FirstName + " " + user.LastName;
            this.role = user.Role.Name;
            this.phoneNumber = user.PhoneNumber; 
            this.lastName = user.LastName;
            this.firstName = user.FirstName;
            this.createDate = user.CreatedDate;
            this.avatar = $"{user.LinkAvatar}/{user.Avatar}";
            foreach (var item in user.ListClassroomInfor)
            {
                listClassroom.Add(new ClassroomInforModel(item));
            }
        }
    }
}
