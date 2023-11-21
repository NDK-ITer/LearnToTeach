﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private IMemoryCache _memoryCache;
        private string _keyValueCache;
        public UserRepository(UserServiceDbContext context, IMemoryCache cache) : base(context)
        {
            _dbSet.Include(u => u.Role).Load();
            _dbSet.Include(u => u.ListClassroomInfor).Load();
            _memoryCache = cache;
            _keyValueCache = "userWhichHaveBeenGet";
        }

        public void Register(User user) => Add(user);
        public void UpdateUser(User user) => Update(user);
        public bool CheckAccountValid(string email, string password)
        {
            var passwordDecode = SecurityMethods.HashPassword(password);
            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache)) 
            {
                var user = listUserInCache.FirstOrDefault(u => u.PresentEmail == email);
                if (user == null) 
                {
                    user = _dbSet.FirstOrDefault(u => u.PresentEmail == email);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        if (user.PasswordHash == passwordDecode)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                else
                {
                    if (user.PasswordHash == passwordDecode)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var listUser = new List<User>();
                var user = _dbSet.FirstOrDefault(u => u.PresentEmail == email && SecurityMethods.HashPassword(password) == u.PasswordHash);
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache, listUser, _options);
                    return true;
                }
                return false;
            }
            
        }
        
        public User? GetUserByUsername(string username)
        {
            if (username.IsNullOrEmpty()) return null;
            
            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache))
            {
                var user = listUserInCache.FirstOrDefault(u => u.UserName == username);
                if (user == null) 
                {
                    user = _dbSet.FirstOrDefault(u => u.UserName == username);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        return user;
                    }
                }
                return user;
            }
            else
            {
                var user = _dbSet.FirstOrDefault(u => u.UserName == username);
                var listUser = new List<User>();
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache,listUser,_options);
                    return user;
                }
                return null;
            }
            
        }
        public User? GetUserByEmail(string email)
        {
            if (email.IsNullOrEmpty()) return null;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache))
            {
                var user = listUserInCache.FirstOrDefault(u => u.PresentEmail == email);
                if (user == null)
                {
                    user = _dbSet.FirstOrDefault(u => u.PresentEmail == email);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        return user;
                    }
                    else
                    {
                        return null;
                    }

                }
                return user;
            }
            else
            {
                var user = _dbSet.FirstOrDefault(u => u.PresentEmail == email);
                var listUser = new List<User>();
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache, listUser, _options);
                    return user;
                }
                return null;
            }

        }
        public User? GetUserById(string id) 
        {
            if (id.IsNullOrEmpty()) return null;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache))
            {
                var user = listUserInCache.FirstOrDefault(u => u.id == id);
                if (user == null)
                {
                    user = _dbSet.Find(id);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        return user;
                    }
                }
                return user;
            }
            else
            {
                var user = _dbSet.Find(id);
                var listUser = new List<User>();
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache, listUser, _options);
                    return user;
                }
                return null;
            }
        }
        public bool CheckEmailIsExist(string email)
        {
            if (email.IsNullOrEmpty()) return false;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache))
            {
                var user = listUserInCache.FirstOrDefault(u => u.PresentEmail == email);
                if (user == null)
                {
                    user = _dbSet.FirstOrDefault(u => u.PresentEmail == email);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var user = _dbSet.FirstOrDefault(u => u.PresentEmail == email);
                var listUser = new List<User>();
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache, listUser, _options);
                    return true;
                }
                return false;
            }
        }

        public bool CheckUsernameIsExist(string username)
        {
            if (username.IsNullOrEmpty()) return false;

            if (_memoryCache.TryGetValue(_keyValueCache, out List<User> listUserInCache))
            {
                var user = listUserInCache.FirstOrDefault(u => u.UserName == username);
                if (user == null)
                {
                    user = _dbSet.FirstOrDefault(u => u.UserName == username);
                    if (user != null)
                    {
                        listUserInCache.Add(user);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var user = _dbSet.FirstOrDefault(u => u.UserName == username);
                var listUser = new List<User>();
                if (user != null)
                {
                    listUser.Add(user);
                    _memoryCache.Set(_keyValueCache, listUser, _options);
                    return true;
                }
                return false;
            }
        }

        public List<User> GetAllUsers() => GetAll();

        public List<User> GetAllUsersWith(System.Linq.Expressions.Expression<Func<User, bool>> predicate) => Find(predicate);
        
        public string GetOTP(string email)
        {
             //var otp = SecurityMethods.CreateRandomOTP();
            if(_memoryCache.TryGetValue(email, out var otpCache))
            {
                string otp = (string)otpCache;
                _memoryCache.Remove(email);
                return otp;
            }
            else
            {
                _memoryCache.Remove(email);
                var otp = SecurityMethods.CreateRandomOTP();
                _memoryCache.Set(email, otp, _options);
                return otp;
            }
            
        }

    }
}
