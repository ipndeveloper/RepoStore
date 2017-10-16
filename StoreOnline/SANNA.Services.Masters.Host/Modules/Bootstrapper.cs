using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;

namespace SANNA.Services.Masters.Host.Modules
{
    public class Bootstrapper
    {
        public static void LoadContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ContextRepositoryModule>();
            builder.RegisterModule<ServicesModule>();
            

            AutofacHostFactory.Container = builder.Build();
        }
    }
}