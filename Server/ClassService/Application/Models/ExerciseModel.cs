using Domain.Entities;
using XAct;

namespace Application.Models
{
    public class ExerciseModel
    {
        public string IdExercise { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkFile { get; set; }
        public ExerciseModel(Exercise exercise)
        {
            IdExercise = exercise.IdExercise;
            if (!exercise.Name.IsNullOrEmpty()) Name = exercise.Name;
            if (!exercise.Description.IsNullOrEmpty()) Description = exercise.Description;
            if (!exercise.LinkFile.IsNullOrEmpty()) LinkFile = exercise.LinkFile;
        }
    }
}
