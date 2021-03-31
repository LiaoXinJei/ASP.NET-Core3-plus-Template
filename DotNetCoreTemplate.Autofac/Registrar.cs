using Autofac;
using DotNetCoreTemplate.Repository.DbBase;
using DotNetCoreTemplate.Repository.DbType;
using DotNetCoreTemplate.Repository.Interface;
using DotNetCoreTemplate.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DotNetCoreTemplate.Autofac
{
    public static class Registrar
    {
        public static void RegisterAssemblies(this ContainerBuilder builder)
        {
            var assemblies = new Assembly[]
            {
                Assembly.Load("DotNetCoreTemplate.Api"),
                Assembly.Load("DotNetCoreTemplate.Service"),
                Assembly.Load("DotNetCoreTemplate.Repository")
            };
            builder.RegisterAssemblyTypes(assemblies)
                .Where(x => (x.Name.EndsWith("Service") || x.Name.EndsWith("Repository")) 
                    && !x.IsInterface)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<MsSql>().As<IDbType>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}
