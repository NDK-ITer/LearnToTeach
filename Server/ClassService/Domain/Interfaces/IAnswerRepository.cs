using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        List<Answer>? GetAnswerInExercise(string idExercise);
    }
}
