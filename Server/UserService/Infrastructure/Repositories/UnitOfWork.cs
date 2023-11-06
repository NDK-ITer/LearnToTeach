using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IRoleRepository roleRepository { get; }
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
        }

        public IUserRepository userRepository { get; private set; }

        public IRoleRepository roleRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
