using Infrastructure.Context;

namespace Application.Services
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
