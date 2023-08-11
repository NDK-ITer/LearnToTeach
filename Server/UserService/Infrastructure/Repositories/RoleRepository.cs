﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationDbContext context) : base(context)
        {
            _dbSet.Include(c => c.Users);
        }
        public Role? GetRoleById(string id) => GetById(id);
        public Role? GetRoleByName(string name) => Find(u => u.Name == name.ToUpper()).FirstOrDefault() as Role;
    }
}
