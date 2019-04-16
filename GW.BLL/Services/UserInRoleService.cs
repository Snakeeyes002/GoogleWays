using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using GW.BLL.Models;
using GW.DAL.DbLayer;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Services
{
    public class UserInRoleService : GenericService<UserInRoleDTO, UserInRole>
    {
        public UserInRoleService(IGenericRepository<UserInRole> repository) : base(repository)
        {
        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<UserInRole, UserInRoleDTO>()
                .ForMember(nameof(UserInRoleDTO.Email), opt => opt.MapFrom(g => g.User.Email))
                .ForMember(nameof(UserInRoleDTO.RoleName), opt => opt.MapFrom(g => g.Role.Title));
                cfg.CreateMap<UserInRoleDTO, UserInRole>();
            }).CreateMapper();
        }
    }
}
