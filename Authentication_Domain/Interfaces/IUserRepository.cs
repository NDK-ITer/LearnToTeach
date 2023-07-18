﻿using Authentication_Domain.Entites;

namespace Authentication_Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void Register(User user);
        void UpdateUser(User user);
        bool CheckAccountValid(string username, string password);
        bool CheckUserIsLocked(User user);
        void LockUser(User user);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User GetUserById(string id);
    }
}
