using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public interface IUnitOfWork_ClassroomService
    {
        IClassroomService _classroomService { get; }
        IMemberService _memberService { get; }
    }
    public class UnitOfWork_ClassroomService : IUnitOfWork_ClassroomService
    {
        public UnitOfWork_ClassroomService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _classroomService = new ClassroomService(context, memoryCache);
            _memberService = new MemberService(context, memoryCache);
        }

        public IClassroomService _classroomService { get; private set; }
        public IMemberService _memberService { get; private set; }
    }
}
