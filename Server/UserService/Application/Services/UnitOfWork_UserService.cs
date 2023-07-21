using Infrastructure.Context;

namespace Application.Services
{
    public interface IUnitOfWork_UserService
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
    public class UnitOfWork_UserService : IUnitOfWork_UserService
    {
        private readonly AuthenticationDbContext _context;

        public UnitOfWork_UserService(AuthenticationDbContext context)
        {
            _context = context;
            AuthenticationService = new AuthenticationService(context);
            UserService = new UserService(context);
            RoleService = new RoleService(context);
        }

        public IAuthenticationService AuthenticationService { get; private set; }

        public IUserService UserService { get; private set; }

        public IRoleService RoleService { get; private set; }
    }
}
