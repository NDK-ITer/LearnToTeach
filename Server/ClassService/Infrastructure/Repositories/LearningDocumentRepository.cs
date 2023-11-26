using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class LearningDocumentRepository : GenericRepository<LearningDocument>, ILearningDocumentRepository
    {
        public LearningDocumentRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(c => c.Classroom).Load();
        }
    }
}
