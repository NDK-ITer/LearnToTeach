using Authentication_Data.Entites;
using System.Linq.Expressions;

namespace Authentication_Infrastructure.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(Expression<Func<User, bool>> where);
        public void AddUser(User entity);
        public void UpdateUser(User entity);
        public void Lock(User entity);
        public bool IsUserExist(Expression<Func<User,bool>> where);
    }
}
