using Infrastructure.Context;

namespace Application.Services
{
    public interface IUnitOfWork_ClassroomService
    {
        IClassroomService _classroomService { get; }
    }
    public class UnitOfWork_ClassroomService : IUnitOfWork_ClassroomService
    {
        public UnitOfWork_ClassroomService(ClassroomDbContext context)
        {
            _classroomService = new ClassroomService(context);
        }

        public IClassroomService _classroomService { get; private set; }
    }
}
