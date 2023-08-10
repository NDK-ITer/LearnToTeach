using Domain.Entities;
using Infrastructure;
using XAct;

namespace Application.Requests
{
    public class UpdateClassroomRepuest
    {
        public string idClassroom { get; set; }
        public string? description { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }

        public void UpdateToClassroom(Classroom classroom)
        {
            if (this.isPrivate == true && this.key.IsNullOrEmpty())
            {
                classroom.KeyHash = KeyHash.Hash(this.key);
                classroom.IsPrivate = this.isPrivate;
            }
            if (!this.description.IsNullOrEmpty()) 
                classroom.Description = this.description;
            if(!this.name.IsNullOrEmpty())
                classroom.Name = this.name;
            
        }
    }
}
