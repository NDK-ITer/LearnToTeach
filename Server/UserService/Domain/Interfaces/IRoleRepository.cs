using Domain.Entites;

namespace Domain.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetRoleById(string id);
        Role GetRoleByName(string name);
    }
}
