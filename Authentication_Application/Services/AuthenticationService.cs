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
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public AuthenticationService(AuthenticationDbContext context)
        {
            _userRepository = new UserRepository(context);
            _roleRepository = new RoleRepository(context);
        }

        public LoginReponse? GetJwtUserInfor(string username, string password)
        {
            var checkLogin = _userRepository.CheckAccountValid(username,password);
            if (!checkLogin) { return null; }
            var user = _userRepository.GetUserByUsername(username);
            user.Role = _roleRepository.GetRoleById(user.RoleId);
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
