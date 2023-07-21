using Application.Requests;
using Domain.Entites;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface IUserService
    {
        bool RegisterUser(RegisterRequest registerRequest);

    }
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(AuthenticationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public bool RegisterUser(RegisterRequest registerRequest)
        {
            try
            {
                var role = _unitOfWork.roleRepository.GetRoleByName("USER");
                var userRegister = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    FirstEmail = registerRequest.Email,
                    PresentEmail = registerRequest.Email,
                    Birthday = registerRequest.Brithday,
                    PasswordHash = PasswordMethod.HashPassword(registerRequest.PasswordIsConfirmed),
                    CreatedDate = DateTime.Now,
                    IsLock = false,
                    RoleId = role.Id,
                    TokenAccess = string.Empty,
                    Role = role
                };

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
