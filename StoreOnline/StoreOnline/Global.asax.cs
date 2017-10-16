using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SANNA.Cross.Helpers.Application;

namespace StoreOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
            //https://codereview.stackexchange.com/questions/122845/repository-pattern-universal-application

            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var culture = ConfigurationManager.AppSettings["CultureLanguage"];
            ApplicationContext.Instance.CurrentCulture = new System.Globalization.CultureInfo(culture);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
          
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CoreContext.CurrentCultureInfo.Name);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CoreContext.CurrentCultureInfo.Name);
       
        }
    }
}
