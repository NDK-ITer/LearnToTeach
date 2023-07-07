using System.Linq.Expressions;

namespace Authentication_Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Delete(Expression<Func<T, bool>> where);
        public int Count(Expression<Func<T, bool>> where);
        public T? GetById(object? id);
        public IEnumerable<T> GetList(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "",
            int skip = 0,
            int take = 0);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        public void SaveChange();
    }
}
