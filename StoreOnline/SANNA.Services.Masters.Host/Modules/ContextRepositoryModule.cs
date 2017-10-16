using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using SANNA.Comun.Data.Core;
using SANNA.Data.IRepository;
using SANNA.Data.Repository;

namespace SANNA.Services.Masters.Host.Modules
{
    public class ContextRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var ConnectionFile = ConfigurationManager.AppSettings["XmlPath"];
            builder.RegisterType<XmlContext>().As<IContext>().WithParameter("DataConnectionString", ConnectionFile.ToString());

            builder.RegisterType<MemoryContext>().As<IContextMemory>();

            //builder.RegisterAssemblyTypes(Assembly.Load("SANNA.Data.Repository"))
            //  .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
            //  .AsImplementedInterfaces()
            //  .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(Assembly.Load("SANNA.Data.Repository"))
                .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(XmlRepository<>))
                .As(typeof(IEntityRepository<>))
                .InstancePerDependency();



            builder.RegisterGeneric(typeof(MemoryRepository<>))
               .As(typeof(IEntityRepository<>))
               //.SingleInstance();
               .InstancePerDependency();



            base.Load(builder);
        }
    }
}