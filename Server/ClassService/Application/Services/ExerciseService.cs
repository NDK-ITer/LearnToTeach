using Domain.Entities;

namespace Application.Services
{
    public interface IExerciseService
    {
        Exercise GetExerciseById(string idExercise);
    }
    public class ExerciseService : IExerciseService
    {
        public Exercise? GetExerciseById(string idExercise)
        {
            try
            {
                //var exercise =
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
