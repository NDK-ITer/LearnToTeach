using Application.Models;
using Application.Requests;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Application.Services
{
    public interface IUserService
    {
        LoginReponse GetJwtUserInfor(string username, string password);
        UserModel RegisterUser(RegisterRequest registerRequest);
        bool EmailIsExist(string email);
        bool UsernameIsExist(string username);
        bool UpdateUser (User user);
        bool LockUser (User user);
        bool CheckUserIsExist(System.Linq.Expressions.Expression<Func<User, bool>> property);
        List<UserModel> GetAllUsers();
        List<UserModel> GetUserWithRole(string roleName);
        UserModel GetUserById(string idUser);
        UserModel GetUserUsername(string username);

    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(AuthenticationDbContext context, IMemoryCache cache)
        {
            _unitOfWork = new UnitOfWork(context, cache);
        }

        public LoginReponse? GetJwtUserInfor(string username, string password)//Login
        {
            var checkLogin = _unitOfWork.userRepository.CheckAccountValid(username, password);
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

        public UserModel? RegisterUser(RegisterRequest registerRequest)
        {
            try
            {
                var role = _unitOfWork.roleRepository.GetRoleByName("USER");
                var userRegister = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    UserName = registerRequest.UserName,
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
                _unitOfWork.userRepository.Register(userRegister);
                _unitOfWork.SaveChange();
                return new UserModel(userRegister);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EmailIsExist(string email)
        {
            if (_unitOfWork.userRepository.CheckEmailIsExist(email)) return true;
            return false;
        }

        public bool UsernameIsExist(string username)
        {
            if(_unitOfWork.userRepository.CheckUsernameIsExist(username)) return true;
            return false;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _unitOfWork.userRepository.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LockUser(User user)
        {
            try
            {
                if (user.IsLock == false) user.IsLock = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserModel>? GetAllUsers()
        {
            try
            {
                var listUser = new List<UserModel>();
                foreach (var item in _unitOfWork.userRepository.GetAllUsers())
                {
                    listUser.Add(new UserModel(item));
                }
                return listUser;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public UserModel? GetUserById(string idUser)
        {
            try
            {
                var user = _unitOfWork.userRepository.GetUserById(idUser);
                if (user == null) return null;
                return new UserModel(user);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<UserModel>? GetUserWithRole(string roleName)
        {
            try
            {
                if(roleName.IsNullOrEmpty()) return null;
                var listUser = new List<UserModel>();
                var users = _unitOfWork.roleRepository.GetRoleByName(roleName).Users;
                if(users == null) return null;  
                foreach (var item in users)
                {
                    listUser.Add(new UserModel(item));
                }
                return listUser;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public UserModel? GetUserUsername(string username)
        {
            try
            {
                var user = _unitOfWork.userRepository.Find(u => u.UserName == username).FirstOrDefault();
                if (user == null) return null;
                var userModel = new UserModel(user);
                return userModel;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool CheckUserIsExist(Expression<Func<User, bool>> property)
        {
            try
            {
                var result = _unitOfWork.userRepository.Find(property);
                if (!result.IsNullOrEmpty())
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
