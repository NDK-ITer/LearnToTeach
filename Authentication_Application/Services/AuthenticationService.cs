using Authentication_Application.Requests;
using Authentication_Domain.Entites;
using Authentication_Infrastructure.Context;
using Authentication_Infrastructure.Repositories;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;

namespace Authentication_Application.Services
{
    public interface IAuthenticationService
    {
        LoginReponse GetJwtUserInfor(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthenticationService(AuthenticationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public LoginReponse? GetJwtUserInfor(string username, string password)
        {
            var checkLogin = _unitOfWork.userRepository.CheckAccountValid(username,password);
            if (!checkLogin) { return null; }
            var user = _unitOfWork.userRepository.GetUserByUsername(username);
            if (user.IsLock == true)
            {
                return null;
            }
            user.Role = _unitOfWork.roleRepository.GetRoleById(user.RoleId);
            var jwtUserInfor = new JwtUserInfor()
            {
                Id = user.id,
                Fullname = user.FirstName + " " + user.LastName,
                Role = user.Role.Name
            };
            return JwtTokenHandler.GenerateJwtToken(jwtUserInfor);
        }

        
    }
}
