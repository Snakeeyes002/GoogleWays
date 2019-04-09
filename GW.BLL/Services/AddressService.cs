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
    public class AddressService : IGenericService<AddressDTO>
    {
        IGenericRepository<Address> addressRepository;
        private readonly IMapper mapper;

        public AddressService(IGenericRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Address, AddressDTO>();
                cfg.CreateMap<AddressDTO, Address>();

            }).CreateMapper();
        }

        public AddressDTO Add(AddressDTO obj)
        {
            Address employee = mapper.Map<Address>(obj);
            addressRepository.AddOrUpdate(employee);
            addressRepository.Save();
            return mapper.Map<AddressDTO>(employee);
        }

        public AddressDTO Delete(int id)
        {
            Address employee = mapper.Map<Address>(id);
            addressRepository.Delete(employee);
            addressRepository.Save();
            return mapper.Map<AddressDTO>(employee);
        }

        public IEnumerable<AddressDTO> FindBy(Expression<Func<AddressDTO, bool>> predicate)
        {
            try
            {
                var predicateAddress = mapper.Map<Expression<Func<Address, bool>>>(predicate);
                return addressRepository.FindBy(predicateAddress)
                    .Select(obj => mapper.Map<AddressDTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public AddressDTO Get(int id)
        {
            Address address = addressRepository.Get(id);
            return mapper.Map<AddressDTO>(address);
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            return addressRepository.GetAll().Select(obj => mapper.Map<AddressDTO>(obj));
        }

        public AddressDTO Update(AddressDTO obj)
        {
            Address address = mapper.Map<Address>(obj);
            addressRepository.AddOrUpdate(address);
            addressRepository.Save();
            return mapper.Map<AddressDTO>(address);
        }
    }
}
