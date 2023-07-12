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
        public T? GetByProperty(Expression<Func<T, bool>> where);
        public IEnumerable<T> GetList(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, bool>>? orderBy = null,
            int take = 0);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        public void SaveChange();
    }
}
