﻿using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork 
    {
        IUserRepository userRepository { get; }
        IRoleRepository roleRepository { get; }
        IClassroomInforRepository classroomRepository { get; }
        void SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserServiceDbContext _context;

        public UnitOfWork(UserServiceDbContext context, IMemoryCache cache)
        {
            _context = context;
            userRepository = new UserRepository(context, cache);
            roleRepository = new RoleRepository(context);
            classroomRepository = new ClassroomInforRepository(context);
        }

        public IUserRepository userRepository { get; private set; }
        public IClassroomInforRepository classroomRepository { get; private set; }
        public IRoleRepository roleRepository { get; private set; }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
