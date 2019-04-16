using GW.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public interface IUnitOfWorkAddress : IUnitOfWork
    {
        IGenericService<AddressDTO> AddressService { get; set; }
        IGenericService<StreetDTO> StreetService { get; set; }
        IGenericService<SubdivisionDTO> SubdivisionService { get; set; }
    }
}
