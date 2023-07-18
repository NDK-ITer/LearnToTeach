using Authentication_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Application.Services
{
    public interface IUnitOfWork_Authenticate
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
    public class UnitOfWork_Authenticate : IUnitOfWork_Authenticate
    {
        private readonly AuthenticationDbContext _context;

        public UnitOfWork_Authenticate(AuthenticationDbContext context)
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
