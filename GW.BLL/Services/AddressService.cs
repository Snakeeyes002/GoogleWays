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
    public class AddressService : GenericService<AddressDTO,Address>
    {
      

        public AddressService(IGenericRepository<Address> addressRepository):base(addressRepository)
        {
           
        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Address, AddressDTO>()
                .ForMember(nameof(AddressDTO.StreetName), opt => opt.MapFrom(g => g.Street.StreetName))
                .ForMember(nameof(AddressDTO.SubdivisionName), opt => opt.MapFrom(g => g.Subdivision.SubdivisionName));
                cfg.CreateMap<AddressDTO, Address>();
            }).CreateMapper();
        }

    }
}
