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
        /// <summary>
        /// AccountController
        /// </summary>
        /// <returns></returns>
        LoginResponses LoginUser(string username, string password);
        User RegisterUser(RegisterRequest registerRequest);
        User ConfirmEmailUser(string id, string token);
        User ResetPasswordUser(string email, string newPassword);
        /// <summary>
        /// Difference
        /// </summary>
        ///  <returns></returns>
        bool EmailIsExist(string email);
        bool UsernameIsExist(string username);
        bool UpdateUser(UpdateUserModel editInforRequest);
        bool LockUser(User user);
        bool CheckUserIsExist(System.Linq.Expressions.Expression<Func<User, bool>> property);
        /// <summary>
        /// UserController
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
        List<User> GetUserWithRole(string roleName);
        User GetUserById(string idUser);
        User GetUserUsername(string username);
        User GetUserByEmail(string email);
        string GetUserToken(string id);
        string GetOtp(string email);
        string verifyOTP(string email);
    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserServiceDbContext context, IMemoryCache cache)
        {
            _unitOfWork = new UnitOfWork(context, cache);
        }


        public LoginResponses? LoginUser(string email, string password)//Login
        {
            var checkLogin = _unitOfWork.userRepository.CheckAccountValid(email, password);
            if (!checkLogin) { return null; }
            var user = _unitOfWork.userRepository.GetUserByEmail(email);
            if (user.IsLock == true)
            {
                return null;
            }
            user.Role = _unitOfWork.roleRepository.GetRoleById(user.RoleId);
            var jwtUserInfor = new JwtUserInfor()
            {
                Id = user.id,
                Email = user.PresentEmail,
                Avatar = $"{user.LinkAvatar}/{user.Avatar}",
                Fullname = user.FirstName + " " + user.LastName,
                Role = user.Role.Name
            };
            return JwtTokenHandler.GenerateJwtToken(jwtUserInfor);
        }

        public User? RegisterUser(RegisterRequest registerRequest)
        {
            try
            {
                var role = _unitOfWork.roleRepository.GetRoleByName("USER");
                var userRegister = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    UserName = string.Empty,
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    FirstEmail = registerRequest.Email,
                    PhoneNumber = registerRequest.PhoneNumber,
                    Avatar = string.Empty,
                    LinkAvatar = string.Empty,
                    PresentEmail = registerRequest.Email,
                    Birthday = registerRequest.Birthday,
                    PasswordHash = SecurityMethods.HashPassword(registerRequest.PasswordIsConfirmed),
                    CreatedDate = DateTime.Now,
                    IsLock = false,
                    RoleId = role.Id,
                    TokenAccess = SecurityMethods.CreateRandomToken(),
                    VerifiedDate = null,
                    IsVerified = false,
                    Role = role
                };
                if (!registerRequest.FirstName.IsNullOrEmpty()) userRegister.FirstName = registerRequest.FirstName;
                if (!registerRequest.LastName.IsNullOrEmpty()) userRegister.LastName = registerRequest.LastName;
                _unitOfWork.userRepository.Register(userRegister);
                _unitOfWork.SaveChange();
                return userRegister;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EmailIsExist(string email)
        {
            if (_unitOfWork.userRepository.Find(e => e.PresentEmail == email).FirstOrDefault() != null) return true;
            return false;
        }

        public bool UsernameIsExist(string username)
        {
            if (_unitOfWork.userRepository.CheckUsernameIsExist(username)) return true;
            return false;
        }

        public bool UpdateUser(UpdateUserModel editInforRequest)
        {
            try
            {
                var user = _unitOfWork.userRepository.Find(p => p.id == editInforRequest.IdUser).FirstOrDefault();
                if (user != null)
                {
                    if (!editInforRequest.FirstName.IsNullOrEmpty()) { user.FirstName = editInforRequest.FirstName; }
                    if (!editInforRequest.LastName.IsNullOrEmpty()) { user.LastName = editInforRequest.LastName; }
                    if (!editInforRequest.Avatar.IsNullOrEmpty()) { user.Avatar = editInforRequest.Avatar; }
                    if (!editInforRequest.LinkAvatar.IsNullOrEmpty()) { user.LinkAvatar = editInforRequest.LinkAvatar; }
                    _unitOfWork.userRepository.Update(user);
                    _unitOfWork.SaveChange();
                    return true;
                }
                return false;
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

        public List<User>? GetAllUsers()
        {
            try
            {
                return _unitOfWork.userRepository.GetAllUsers();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public User? GetUserById(string idUser)
        {
            try
            {
                var user = _unitOfWork.userRepository.GetById(idUser);
                if (user == null) return null;
                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<User>? GetUserWithRole(string roleName)
        {
            try
            {
                if (roleName.IsNullOrEmpty()) return null;

                var users = _unitOfWork.roleRepository.GetRoleByName(roleName).Users;
                if (users == null) return null;

                return users;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public User? GetUserUsername(string username)
        {
            try
            {
                var user = _unitOfWork.userRepository.Find(u => u.UserName == username).FirstOrDefault();
                if (user == null) return null;
                return user;
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

        public string? GetUserToken(string id)
        {
            try
            {
                var tokenAccess = _unitOfWork.userRepository.GetUserById(id).TokenAccess;
                return tokenAccess;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public User? ConfirmEmailUser(string id, string token)
        {
            try
            {
                var userNeedVerify = _unitOfWork.userRepository.GetUserById(id);

                if (userNeedVerify == null) return null;
                if (userNeedVerify.TokenAccess != token) return null;
                if (userNeedVerify.IsVerified == false)
                {
                    userNeedVerify.IsVerified = true;
                    userNeedVerify.VerifiedDate = DateTime.Now;

                    _unitOfWork.userRepository.UpdateUser(userNeedVerify);
                    _unitOfWork.SaveChange();
                }
                return userNeedVerify;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User? ResetPasswordUser(string email, string newPassword)
        {
            try
            {
                var user = _unitOfWork.userRepository.GetUserByEmail(email);
                user.PasswordHash = SecurityMethods.HashPassword(newPassword);
                _unitOfWork.SaveChange();
                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public User? GetUserByEmail(string email)
        {
            try
            {
                if (email.IsNullOrEmpty()) return null;
                var user = _unitOfWork.userRepository.GetUserByEmail(email);
                if (user != null) return user;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string? GetOtp(string email)
        {
            return _unitOfWork.userRepository.GetOTP(email);
        }
        public string? verifyOTP(string email)
        {
            return _unitOfWork.userRepository.verifyOTP(email);
        }
    }
}
