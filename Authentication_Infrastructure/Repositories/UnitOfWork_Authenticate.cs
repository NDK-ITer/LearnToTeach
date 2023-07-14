using Authentication_Domain.Interfaces;
using Authentication_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Infrastructure.Repositories
{
    public class UnitOfWork_Authenticate : IUnitOfWork_Authenticate
    {
        private readonly AuthenticationDbContext _context;

        public UnitOfWork_Authenticate(AuthenticationDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Role = new RoleRepository(_context);
        }

        public IUserRepository User {get; private set;}

        public IRoleRepository Role { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChange()
        {
           return _context.SaveChanges();
        }
    }
}
