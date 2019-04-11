using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using GW.BLL.Models;
using GW.DAL.DbLayer;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public class SubdivisionService : GenericService<SubdivisionDTO, Subdivision>
    {
        public SubdivisionService(IGenericRepository<Subdivision> repository) : base(repository)
        {
        }
    }

}
