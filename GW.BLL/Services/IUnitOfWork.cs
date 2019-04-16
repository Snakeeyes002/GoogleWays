using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GW.BLL.Services
{
    public interface IUnitOfWork : IDisposable
    {
        TransactionScope Transaction { get; set; }
        void Commit();
        void Rollback();
    }
}
