using Authentication_Data.EF;
using Authentication_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Authentication_Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AuthenticationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AuthenticationDbContext dbContext) 
        { 
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public int Count(Expression<Func<T, bool>> where) => _dbSet.Count(where);

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects) 
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual IEnumerable<T> GetAll() => _dbSet.AsEnumerable();

        public virtual T? GetById(object? id) => _dbSet.Find(id);

        public virtual IEnumerable<T> GetList(
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            string includeProperties = "", 
            int skip = 0, 
            int take = 0)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SaveChange() => _dbContext.SaveChanges();
    }
}