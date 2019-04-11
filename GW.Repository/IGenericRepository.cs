using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GW.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Find(params object[] keys);

        void Add(T entity);

        void Delete(T entity);

        void Delete(params object[] keys);

        void Update(T entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
