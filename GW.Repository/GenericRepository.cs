using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GW.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {

        private readonly DbContext context;
        private readonly IDbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(params object[] keys)
        {
            var entity = dbSet.Find(keys);
            dbSet.Remove(entity);
        }

        public T Find(params object[] keys)
        {
            return dbSet.Find(keys);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsNoTracking();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            dbSet.AddOrUpdate(entity);
        }
    }
}
