using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(p => p.Member);
            _dbSet.Include(p => p.Exercise);
        }
        public List<Answer>? GetAnswerInExercise(string idExercise) => Find(p => p.IdExercise == idExercise).ToList();
    }
}
