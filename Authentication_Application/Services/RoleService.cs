using Authentication_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Application.Services
{
    public interface IRoleService
    {

    }
    public class RoleService : IRoleService
    {
        private readonly AuthenticationDbContext _context;

        public RoleService(AuthenticationDbContext context) 
        {
            _context = context;
        }   
    }
}
