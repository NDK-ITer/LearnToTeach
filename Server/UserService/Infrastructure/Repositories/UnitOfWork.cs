using Domain.Interfaces;
using Infrastructure.Context;

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
        private readonly AuthenticationDbContext _context;

        public UnitOfWork(AuthenticationDbContext context)
        {
            _context = context;
            userRepository = new UserRepository(context);
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
