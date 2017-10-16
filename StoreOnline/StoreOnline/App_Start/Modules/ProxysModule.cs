using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using Autofac;
using Autofac.Builder;

namespace StoreOnline.Modules
{
    public partial class ProxysModule : Autofac.Module
    {


        protected override void Load(ContainerBuilder builder)
        {
            ServiceProxy(builder);
        }
        private static void ServiceProxy(ContainerBuilder builder)
        {
            NameValueCollection keys = ConfigurationManager.AppSettings;
            const string host = "Host.Url";
            const string binding = "Host.Binding";
            var b = ContainerBuilderExtensions.MakeBinding(keys[binding]);

           
            string baseMaestros = host;
          
          
            baseMaestros = "Maestros.Host.Url";


            //TODO: Colocar Metodo aqui si hay mas modulos
            /****Los Metodos se Generan automaticamente en la Plantilla T4: RegisterProxys.tt***/
            /****Para Nuevos Modulos, Agregue la Carpeta y el NameSpace de Contratos en: RegisterProxys.tt***/


            Masters_ServiceProxy(builder, new Uri(keys[baseMaestros]), b);
           
        }
    }

    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TChannel, SimpleActivatorData, SingleRegistrationStyle> RegisterServiceProxy<TChannel>(this ContainerBuilder builder, Uri baseUri, Binding binding, string relativeUri)
        {
            builder.Register(c => new ChannelFactory<TChannel>(binding, new EndpointAddress(new Uri(baseUri, relativeUri)))).SingleInstance();
            return builder.Register(c => c.Resolve<ChannelFactory<TChannel>>().CreateChannel()).InstancePerLifetimeScope();
        }

        public static Binding MakeBinding(string @bindingName)
        {
            // Bindings Soportados en el Servidor de Servicios

            Binding binding = null;
            switch (@bindingName)
            {
                case "basicHttpBinding":
                    binding = new BasicHttpBinding("proxyHttpBinding");
                    break;
                case "customBinding":
                    binding = new CustomBinding("proxyHttpBinding");
                    break;

            }
            //Es el mismo nombre que el web.config
            return binding;
        }
    }
}