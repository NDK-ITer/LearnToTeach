using Authentication_Data.EF;
using Authentication_Data.Entites;
using Authentication_Infrastructure.Repositories;
using Authentication_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Repositories.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }

        public void AddRole(Role role) => Insert(role);

        public IEnumerable<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetListRole(Expression<Func<Role, bool>> where) => GetAllRoles();

        public Role GetRole(Expression<Func<Role, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void RemoveRole(Role role) => Delete(role);
        
    }
}
