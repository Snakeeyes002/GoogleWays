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
    public class StreetRepository : GenericRepository<Street>
    {
        public StreetRepository(DbContext context) : base(context)
        { }
    }
}
