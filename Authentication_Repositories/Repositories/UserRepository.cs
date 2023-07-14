using Authentication_Domain.Entites;
using Authentication_Infrastructure.Context;
using Authentication_Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace Authentication_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }

        public User? GetUser(Expression<Func<User, bool>> where)
        {
            var user = (User)_dbSet.Where(where);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public void AddUser(User entity) => Insert(entity);

        public IEnumerable<User> GetUsers() => _dbSet.AsEnumerable();

        public bool IsUserExist(Expression<Func<User, bool>> where)
        {
            var user = _dbSet.Where(where).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public void Lock(User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User entity) => Update(entity);
    }
}
