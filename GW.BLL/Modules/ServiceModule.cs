using Autofac;
using GW.BLL.Models;
using GW.BLL.Services;
using GW.DAL.DbLayer;
using GW.DAL.Repositories;
using GW.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace GW.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Address
            builder.RegisterType(typeof(AddressService))
                            .As(typeof(IGenericService<AddressDTO>));
            builder.RegisterType(typeof(AddressRepository))
                          .As(typeof(IGenericRepository<Address>));
            //Street
            builder.RegisterType(typeof(StreetService))
                .As(typeof(IGenericService<StreetDTO>));
            builder.RegisterType(typeof(StreetRepository))
                          .As(typeof(IGenericRepository<Street>));
            //Subdivision
            builder.RegisterType(typeof(SubdivisionService))
                .As(typeof(IGenericService<SubdivisionDTO>));
            builder.RegisterType(typeof(SubdivisionRepository))
                          .As(typeof(IGenericRepository<Subdivision>));


            builder.RegisterType(typeof(GWContext))
                         .As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }
}
