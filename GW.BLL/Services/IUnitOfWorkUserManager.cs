using GW.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GW.BLL.Services
{
    public interface IUnitOfWorkUserManager : IUnitOfWork
    {
        TransactionScope Transaction { get; set; }
        IGenericService<UserDTO> UserService { get; set; }
        IGenericService<RoleDTO> RoleService { get; set; }
        IGenericService<UserInRoleDTO> UserInRoleService { get; set; }
    }
}
