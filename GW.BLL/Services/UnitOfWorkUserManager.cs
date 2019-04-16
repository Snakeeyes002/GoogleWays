using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using GW.BLL.Models;

namespace GW.BLL.Services
{
    public class UnitOfWorkUserManager : IUnitOfWorkUserManager
    {
        private bool disposed = false;
        public TransactionScope Transaction { get; set; }
        public IGenericService<UserDTO> UserService { get; set; }
        public IGenericService<RoleDTO> RoleService { get; set; }
        public IGenericService<UserInRoleDTO> UserInRoleService { get; set; }
        public UnitOfWorkUserManager(TransactionScope transaction,
                                     IGenericService<UserDTO> userService,
                                     IGenericService<RoleDTO> roleService,
                                     IGenericService<UserInRoleDTO> userInRoleService)
        {
            this.Transaction = transaction;
            this.UserService = userService;
            this.RoleService = roleService;
            this.UserInRoleService = userInRoleService;
        }

        public void Commit()
        {
            Transaction.Complete();
        }

        public void Rollback()
        {
            Transaction.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Transaction.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
