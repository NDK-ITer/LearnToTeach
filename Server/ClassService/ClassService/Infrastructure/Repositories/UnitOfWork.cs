using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IClassroomRepository classroomRepository { get; }
        IClassroomDetailRepository classroomDetailRepository { get; }
        void SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClassroomDbContext _context;

        public UnitOfWork(ClassroomDbContext context)
        {
            _context = context;
            classroomDetailRepository = new ClassroomDetailRepository(context);
            classroomRepository = new ClassroomRepository(context);
        }
        public IClassroomRepository classroomRepository { get; private set; }

        public IClassroomDetailRepository classroomDetailRepository { get; private set; }

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
