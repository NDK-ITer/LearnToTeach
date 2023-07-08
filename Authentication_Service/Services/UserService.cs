using Authentication_Data.Entites;
using Authentication_Infrastructure.Interfaces;
using Authentication_Service.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public void Register(RegisterRequest register)
        {
            var id = Guid.NewGuid().ToString();
            var user = new User()
            {
                UserName = register.UserName,
                UserRoles = new List<UserRole>() { new UserRole() {UserId = id,} }
            };
        }
    }
}
