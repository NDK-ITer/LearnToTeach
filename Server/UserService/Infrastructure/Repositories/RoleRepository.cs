using Domain.Entites;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationDbContext context) : base(context)
        {

        }
        public Role? GetRoleById(string id) => GetById(id);
        public Role? GetRoleByName(string name) => Find(u => u.Name == name.ToUpper()).FirstOrDefault() as Role;
    }
}
