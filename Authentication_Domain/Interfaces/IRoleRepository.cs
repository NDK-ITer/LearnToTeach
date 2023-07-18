using Authentication_Domain.Entites;

namespace Authentication_Domain.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetRoleById(string id);
        Role GetRoleByName(string name);
    }
}
