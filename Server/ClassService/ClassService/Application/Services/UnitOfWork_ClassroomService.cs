using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public interface IUnitOfWork_ClassroomService
    {
        IClassroomService _classroomService { get; }
    }
    public class UnitOfWork_ClassroomService : IUnitOfWork_ClassroomService
    {
        public UnitOfWork_ClassroomService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _classroomService = new ClassroomService(context, memoryCache);
        }

        public IClassroomService _classroomService { get; private set; }
    }
}
