using System.Linq.Expressions;

namespace SMS.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        public T FindById(int id);
    }
}
