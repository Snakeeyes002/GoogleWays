using GW.BLL.Models;
using GW.DAL.DbLayer;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public class RoleService : GenericService<RoleDTO, Role>
    {
        public RoleService(IGenericRepository<Role> repository) : base(repository)
        {
        }
    }
}
