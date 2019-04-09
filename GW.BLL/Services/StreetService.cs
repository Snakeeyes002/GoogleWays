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
    public class StreetService : IGenericService<StreetDTO>
    {
        IGenericRepository<Street> streetRepository;
        private readonly IMapper mapper;

        public StreetService(IGenericRepository<Street> streetRepository)
        {
            this.streetRepository = streetRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<StreetDTO, Street>();

            }).CreateMapper();
        }

        public StreetDTO Add(StreetDTO obj)
        {
            Street street = mapper.Map<Street>(obj);
            streetRepository.AddOrUpdate(street);
            streetRepository.Save();
            return mapper.Map<StreetDTO>(street);
        }

        public StreetDTO Delete(int id)
        {
            Street street = mapper.Map<Street>(id);
            streetRepository.Delete(street);
            streetRepository.Save();
            return mapper.Map<StreetDTO>(street);
        }

        public IEnumerable<StreetDTO> FindBy(Expression<Func<StreetDTO, bool>> predicate)
        {
            try
            {
                var predicateStreet = mapper.Map<Expression<Func<Street, bool>>>(predicate);
                return streetRepository.FindBy(predicateStreet)
                    .Select(obj => mapper.Map<StreetDTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public StreetDTO Get(int id)
        {
            Street street = streetRepository.Get(id);
            return mapper.Map<StreetDTO>(street);
        }

        public IEnumerable<StreetDTO> GetAll()
        {
            return streetRepository.GetAll().Select(obj => mapper.Map<StreetDTO>(obj));
        }

        public StreetDTO Update(StreetDTO obj)
        {
            Street street = mapper.Map<Street>(obj);
            streetRepository.AddOrUpdate(street);
            streetRepository.Save();
            return mapper.Map<StreetDTO>(street);
        }
    }
}

