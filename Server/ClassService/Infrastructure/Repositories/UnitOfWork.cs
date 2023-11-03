using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IClassroomRepository classroomRepository { get; }
        IMemberClassroomRepository memberClassroomRepository { get; }
        void SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClassroomDbContext _context;

        public UnitOfWork(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            classroomRepository = new ClassroomRepository(context, memoryCache);
            memberClassroomRepository = new MemberClassroomRepository(context, memoryCache);
        }
        public IClassroomRepository classroomRepository { get; private set; }
        public IMemberClassroomRepository memberClassroomRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
