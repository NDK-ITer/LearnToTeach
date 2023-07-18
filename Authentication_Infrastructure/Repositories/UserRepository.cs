using Authentication_Domain.Entites;
using Authentication_Domain.Interfaces;
using Authentication_Infrastructure.Context;

namespace Authentication_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AuthenticationDbContext context) : base(context)
        {

        }

        public void Register(User user) => Add(user);
        public void UpdateUser(User user) => Update(user);
        public bool CheckAccountValid(string username, string password)
        {
            var temp = PasswordMethod.HashPassword(password);
            var user = Find(u => u.UserName == username && PasswordMethod.HashPassword(password) == u.PasswordHash).FirstOrDefault() as User;
            if (user == null)
            {
                return false;
            }
            return true;
        }
        public bool CheckUserIsLocked(User user)
        {
            if (user.IsLock == false) return false;
            return true;
        }
        public void LockUser(User user)
        {
            if (user.IsLock == true)
            {
                return;
            }
            user.IsLock = true;
        }
        public User? GetUserByUsername(string username)
        {
            var user = Find(u => u.UserName == username).FirstOrDefault() as User;
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User? GetUserByEmail(string email)
        {
            var user = Find(u => u.PresentEmail == email).FirstOrDefault() as User;
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User? GetUserById(string id) => GetById(id);
    }
}
