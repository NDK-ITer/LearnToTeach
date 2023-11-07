using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public interface IUnitOfWork_UserService
    {
        IClassroomInforService ClassroomInforService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
    public class UnitOfWork_UserService : IUnitOfWork_UserService
    {
        public UnitOfWork_UserService(UserServiceDbContext context, IMemoryCache cache)
        {
            UserService = new UserService(context, cache);
            RoleService = new RoleService(context);
            ClassroomInforService = new ClassroomInforService(context, cache);
        }

        public IClassroomInforService ClassroomInforService { get; private set; }
        public IUserService UserService { get; private set; }
        public IRoleService RoleService { get; private set; }
    }
}
