using Application.Models.Exercise;
using Application.Models.Member;
using Domain.Entities;
using System.Data;
using XAct;

namespace Application.Models.Classroom
{
    public class ClassroomModel
    {
        public string? idClassroom { get; set; }
        public string? avatarClassroom { get; set; }
        public string? description { get; set; }
        public string? key { get; set; }
        public string? name { get; set; }
        public bool isPrivate { get; set; }
        public List<MemberModel>? ListMembers { get; set; } = new List<MemberModel>();
        public List<ExerciseModel>? ListExercises { get; set; } = new List<ExerciseModel>();
        public ClassroomModel(Classroom classroom)
        {
            if (classroom != null)
            {
                idClassroom = classroom.Id;
                avatarClassroom = $"{classroom.LinkAvatar}/{classroom.Avatar}";
                name = classroom.Name;
                description = classroom.Description;
                foreach (var item in classroom.ListMember)
                {
                    ListMembers.Add(new MemberModel(item, classroom.Id));
                }
                foreach (var item in classroom.ListExercise)
                {
                    ListExercises.Add(new ExerciseModel(item));
                }
            }
        }
    }
}
