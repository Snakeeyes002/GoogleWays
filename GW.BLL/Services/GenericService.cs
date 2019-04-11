using AutoMapper;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Extensions.ExpressionMapping;

namespace GW.BLL.Services
{
    public abstract class GenericService<TDto, TOriginal> : IGenericService<TDto> where TOriginal : class, new()
    {
        private readonly IGenericRepository<TOriginal> repository;
        private readonly IMapper mapper;
        public GenericService(IGenericRepository<TOriginal> repository)
        {
            this.repository = repository;

            //Иницилизируем автомапер
            mapper = GetMapper();
        }

        public virtual IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<TOriginal, TDto>();
                cfg.CreateMap<TDto, TOriginal>();

            }).CreateMapper();
        }

        public TDto Add(TDto entity)
        {
            var obj = mapper.Map<TOriginal>(entity);
            repository.Add(obj);
            repository.SaveChanges();
            return mapper.Map<TDto>(obj);
        }

        public TDto Find(params object[] keys)
        {
            var obj = repository.Find(keys);
            return mapper.Map<TDto>(obj);
        }

        public IEnumerable<TDto> FindBy(Expression<Func<TDto, bool>> predicate)
        {
            var objPredicate = mapper.Map<Expression<Func<TOriginal, bool>>>(predicate);
            return repository.FindBy(objPredicate)
                             .Select(obj => mapper.Map<TDto>(obj));
        }

        public IEnumerable<TDto> GetAll()
        {
            return repository.GetAll().Select(obj => mapper.Map<TDto>(obj));
        }

        public TDto Delete(TDto entity)
        {
            var obj = mapper.Map<TOriginal>(entity);
            repository.Delete(obj);
            repository.SaveChanges();
            return entity;
        }

        public TDto Delete(params object[] keys)
        {
            var obj = this.Find(keys);
            repository.Delete(keys);
            repository.SaveChanges();
            return obj;
        }

        public TDto Update(TDto entity)
        {
            var obj = mapper.Map<TOriginal>(entity);
            repository.Update(obj);
            repository.SaveChanges();
            return mapper.Map<TDto>(obj);
        }
    }
}
