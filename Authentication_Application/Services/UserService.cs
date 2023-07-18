using Authentication_Domain.Interfaces;
using Authentication_Infrastructure.Context;
using Authentication_Infrastructure.Repositories;

namespace Authentication_Application.Services
{
    public interface IUserService
    {

    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(AuthenticationDbContext context)
        {
            _userRepository = new UserRepository(context);
        }

    }
}
