using Infrastructure.Context;

namespace Application.Services
{
    public interface IRoleService
    {

    }
    public class RoleService : IRoleService
    {
        private readonly UserServiceDbContext _context;

        public RoleService(UserServiceDbContext context) 
        {
            _context = context;
        }   
    }
}
