using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public interface IGenericService<T> 
    {

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Find(params object[] keys);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Delete(params object[] keys);
    }
}
