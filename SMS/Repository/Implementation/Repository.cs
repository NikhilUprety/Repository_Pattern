using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Repository.Interface;
using System;
using System.Linq.Expressions;

namespace SMS.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public DbSet<T> database;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
           this. database = appDbContext.Set<T>();
            
        }

        public void Add(T entity)
        {
            database.Add(entity);
        }

        public T FindById(int id)
        {
          return  database.Find(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = database;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return database.ToList();
        }
    
        public void Remove(T entity)
        {
            database.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            database.RemoveRange(entities);
        }
    }
}
