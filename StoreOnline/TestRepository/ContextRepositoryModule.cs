using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SANNA.Comun.Data.Core;
using System.Reflection;
using SANNA.Data.Repository;
using SANNA.Data.IRepository;

namespace TestRepository
{
    public class ContextRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<XmlContext>().As<IContext>().WithParameter("DataConnectionString", @"C:\Users\juan.pinedo\Documents\visual studio 2017\Projects\StoreOnline\Files\");

            builder.RegisterAssemblyTypes(Assembly.Load("SANNA.Data.Repository"))
                .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(XmlRepository<>))
                .As(typeof(IEntityRepository<>))
                .InstancePerDependency();

            base.Load(builder);

        }
    }
}
