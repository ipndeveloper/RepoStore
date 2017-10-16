
//===================================================================================
// Template T4 for WCF Services Proxys
// NO Editar manualmente esta Clase
//===================================================================================
using Autofac;
using SANNA.Services.Masters.Interfaces;

using System;
using System.ServiceModel.Channels;

namespace StoreOnline.Modules
{
    public partial class ProxysModule
    {
        //============================================================================================================
        // Registra en el contenedor Instancias de Servicios Proxys para : SANNA.Services.Masters.Interfaces
        //============================================================================================================
		public static void Masters_ServiceProxy(ContainerBuilder builder, Uri uriHost, Binding binding)
		{
			builder.RegisterServiceProxy<IProductService>(uriHost, binding, "Masters/ProductService.svc");            
			builder.RegisterServiceProxy<IProductXmlService>(uriHost, binding, "Masters/ProductXmlService.svc");            
 
		}
 
    }    
}
