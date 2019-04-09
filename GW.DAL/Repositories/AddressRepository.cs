using GW.DAL.DbLayer;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.DAL.Repositories
{
    public class AddressRepository : GenericRepository<Address>
    {
        public AddressRepository(DbContext context) : base(context)
        { }
    }
}
