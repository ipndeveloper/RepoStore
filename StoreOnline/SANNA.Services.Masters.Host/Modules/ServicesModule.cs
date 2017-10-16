using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace SANNA.Services.Masters.Host.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("SANNA.Services.Masters.Services"))
                .Where(type => type.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("SANNA.Aplication.Masters.Repository"))
                .Where(type => type.Name.EndsWith("Aplication", StringComparison.Ordinal))
                .AsImplementedInterfaces();
        }
    }
}