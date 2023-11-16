using Domain.Entities;

namespace Application.Models
{
    public class ClassroomInforModel
    {
        public string? IdClassroom { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }

        public ClassroomInforModel()
        {
            
        }
        public ClassroomInforModel(ClassroomInfor classroomInfor)
        {
            IdClassroom = classroomInfor.IdClassroom;
            Name = classroomInfor.Name;
            Description = classroomInfor.Description;
            Avatar = $"{classroomInfor.LinkAvatar}/{classroomInfor.Avatar}";
        }
    }
}
