using Authentication_Infrastructure.Context;
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

        public T? GetByProperty(Expression<Func<T, bool>> where) => _dbSet.FirstOrDefault(where);

        public virtual IEnumerable<T>? GetList(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, bool>>? orderBy = null,
            int take = 0)
        {
            IQueryable<T> list = _dbSet;
            if (list == null)
                return null;
            if (filter != null)
                list = list.Where(filter);
            if (orderBy != null)
                list = list.OrderBy(orderBy);
            if (take >= 0)
                list = list.Take(take);
            return list;
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