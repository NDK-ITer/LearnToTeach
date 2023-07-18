﻿using Authentication_Domain.Entites;
using Authentication_Domain.Interfaces;
using Authentication_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationDbContext context) : base(context)
        {

        }
        public Role? GetRoleById(string id) => GetById(id);
        public Role? GetRoleByName(string name) => Find(u => u.Name == name.ToUpper()).FirstOrDefault() as Role;
    }
}
