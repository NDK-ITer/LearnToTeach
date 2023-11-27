using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(p => p.ListAnswer).Load();
            _dbSet.Include(p => p.ListMember).Load();
            _dbSet.Include(p => p.Classroom).Load();
        }

        public List<Exercise>? GetExerciseInClassroom(string idClassroom) => Find(p => p.IdClassroom == idClassroom).ToList();
    }
}
