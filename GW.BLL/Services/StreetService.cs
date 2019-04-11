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
    public class StreetService : GenericService<StreetDTO,Street>
    {

        public StreetService(IGenericRepository<Street> Repository) : base(Repository)
        {

        }
       
    }
}

