using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IExerciseRepository: IGenericRepository<Exercise>
    {
        List<Exercise>? GetExerciseInClassroom(string idClassroom);
    }
}
