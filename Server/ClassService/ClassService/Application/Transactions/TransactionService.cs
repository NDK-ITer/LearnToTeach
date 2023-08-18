using Infrastructure.Context;

namespace Application.Transactions
{
    public class TransactionService
    {
        private readonly ClassroomDbContext _context;

        public TransactionService(ClassroomDbContext context)
        {
            _context = context;
        }

        public void ExecuteTransaction(Action action)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                action();
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }
    }
}
