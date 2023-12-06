using Application.Models.ModelOfLearningDocument;
using Application.Models.ModelOfNotifyClassroom;
using Application.Models.ModelsOfExercise;
using Application.Models.ModelsOfMember;
using Domain.Entities;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace Application.Models.ModelsOfClassroom
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
        public List<LearningDocumentModel>? ListDocument { get; set; } = new List<LearningDocumentModel>();
        public List<NotifyClassroomModel>? ListNotify { get; set; } = new List<NotifyClassroomModel>();
        public ClassroomModel(Classroom classroom)
        {
            if (classroom != null)
            {
                idClassroom = classroom.Id;
                avatarClassroom = $"{classroom.LinkAvatar}/{classroom.Avatar}";
                name = classroom.Name;
                description = classroom.Description;
                key = classroom.KeyHash.IsNullOrEmpty()? null: KeyHash.Decode(classroom.KeyHash);
                isPrivate = classroom.IsPrivate;
                foreach (var item in classroom.ListMember)
                {
                    ListMembers.Add(new MemberModel(item, classroom.Id));
                }
                foreach (var item in classroom.ListExercise)
                {
                    ListExercises.Add(new ExerciseModel(item));
                }
                foreach (var item in classroom.ListDocument)
                {
                    ListDocument.Add(new LearningDocumentModel(item));
                }
                foreach (var item in classroom.ListNotifies)
                {
                    ListNotify.Add(new NotifyClassroomModel(item));
                }
            }
        }
    }
}
