using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class NotifyClassroomRepository : GenericRepository<NotifyClassroom>, INotifyClassroomRepository
    {
        public NotifyClassroomRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(c => c.Classroom).Load();
        }
    }
}
