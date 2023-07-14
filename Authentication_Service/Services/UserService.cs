using Authentication_Domain.Entites;
using Authentication_Repositories;
using Authentication_Service.DTOs.Requests;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;

namespace Authentication_Service.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void Register(RegisterRequest register)
        {
            try
            {
                var userId = Guid.NewGuid().ToString();
                var user = new User()
                {
                    UserName = register.UserName,
                };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public AuthenticationReponse? Login(AuthenticationRequest request)
        {
            try
            {
                var userCheck = _unitOfWork.UserRepository.GetByProperty(u => u.UserName == request.UserName && u.PasswordHash == PasswordMethod.HasPassword(request.Password));
                if (userCheck == null)
                {
                    return null;
                }
                var user = new UserAccount()
                {
                    UserName = userCheck.UserName,
                    Id = userCheck.id,
                };
                var response = JwtTokenHandler.GenerateJwtToken(user);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
