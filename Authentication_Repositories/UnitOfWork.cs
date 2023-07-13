using Authentication_Infrastructure.Context;
using Authentication_Infrastructure.Interfaces;
using Authentication_Infrastructure.Repositories;

namespace Authentication_Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthenticationDbContext _dbContext;

        public UnitOfWork(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_dbContext);
                }
                return userRepository;
            }
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
