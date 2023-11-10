using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void Register(User user);
        void UpdateUser(User user);
        bool CheckAccountValid(string email, string password);
        bool CheckEmailIsExist(string email);
        bool CheckUsernameIsExist(string username);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User GetUserById(string id);
        List<User> GetAllUsers();
        List<User> GetAllUsersWith(System.Linq.Expressions.Expression<Func<User, bool>> predicate);
    }
}
