using Authentication_Data.Entites;
using Authentication_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public void AddRole(Role role);
        public void RemoveRole(Role role);
        public IEnumerable<Role> GetAllRoles();
        public Role GetRole(Expression<Func<Role,bool>> where);
        public IEnumerable<Role> GetListRole(Expression<Func<Role, bool>> where);
    }
}
