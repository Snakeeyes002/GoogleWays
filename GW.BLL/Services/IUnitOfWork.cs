using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
