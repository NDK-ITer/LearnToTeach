using Application.Models.ModelsOfAnswer;
using Domain.Entities;
using XAct;

namespace Application.Models.ModelsOfExercise
{
    public class ExerciseModel
    {
        public string IdExercise { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public List<AnswerModel> ListAnswer { get; set; }
        public ExerciseModel(Exercise exercise)
        {
            IdExercise = exercise.IdExercise;
            ListAnswer = new List<AnswerModel>();
            if (!exercise.Name.IsNullOrEmpty()) Name = exercise.Name;
            if (!exercise.Description.IsNullOrEmpty()) Description = exercise.Description;
            if (!exercise.LinkFile.IsNullOrEmpty()) File = $"{exercise.LinkFile}/{exercise.FileName}";
            foreach (var item in exercise.ListAnswer)
            {
                ListAnswer.Add(new AnswerModel(item));
            }
        }
    }
}
