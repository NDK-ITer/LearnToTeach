using Domain.Entities;

namespace Application.Models.ModelOfNotifyClassroom
{
    public class NotifyClassroomModel
    {
        public string IdNotify { get; set; }
        public DateTime? CreateDate { get; set; }
        public string NameNotify { get; set; }
        public string Description { get; set; }
        public NotifyClassroomModel(NotifyClassroom notify)
        {
            IdNotify = notify.IdNotify;
            CreateDate = notify.CreateDate;
            NameNotify = notify.NameNotify;
            Description = notify.Description;
        }
    }
}
