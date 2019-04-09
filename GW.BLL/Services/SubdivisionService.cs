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
    public class SubdivisionService : IGenericService<SubdivisionDTO>
    {
        IGenericRepository<Subdivision> subdivisionRepository;
        private readonly IMapper mapper;

        public SubdivisionService(IGenericRepository<Subdivision> subdivisionRepository)
        {
            this.subdivisionRepository = subdivisionRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Subdivision, SubdivisionDTO>();
                cfg.CreateMap<SubdivisionDTO, Subdivision>();

            }).CreateMapper();
        }

        public SubdivisionDTO Add(SubdivisionDTO obj)
        {
            Subdivision subdivision = mapper.Map<Subdivision>(obj);
            subdivisionRepository.AddOrUpdate(subdivision);
            subdivisionRepository.Save();
            return mapper.Map<SubdivisionDTO>(subdivision);
        }

        public SubdivisionDTO Delete(int id)
        {
            Subdivision subdivision = mapper.Map<Subdivision>(id);
            subdivisionRepository.Delete(subdivision);
            subdivisionRepository.Save();
            return mapper.Map<SubdivisionDTO>(subdivision);
        }

        public IEnumerable<SubdivisionDTO> FindBy(Expression<Func<SubdivisionDTO, bool>> predicate)
        {
            try
            {
                var predicateSubdivision = mapper.Map<Expression<Func<Subdivision, bool>>>(predicate);
                return subdivisionRepository.FindBy(predicateSubdivision)
                    .Select(obj => mapper.Map<SubdivisionDTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public SubdivisionDTO Get(int id)
        {
            Subdivision subdivision = subdivisionRepository.Get(id);
            return mapper.Map<SubdivisionDTO>(subdivision);
        }

        public IEnumerable<SubdivisionDTO> GetAll()
        {
            return subdivisionRepository.GetAll().Select(obj => mapper.Map<SubdivisionDTO>(obj));
        }

        public SubdivisionDTO Update(SubdivisionDTO obj)
        {
            Subdivision subdivision = mapper.Map<Subdivision>(obj);
            subdivisionRepository.AddOrUpdate(subdivision);
            subdivisionRepository.Save();
            return mapper.Map<SubdivisionDTO>(subdivision);
        }
    }

}
