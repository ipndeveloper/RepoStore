using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Cross.Helpers.Application
{
    public class ApplicationContext
    {
        #region Singleton
        private static object _syncRoot = new object();
        public static ApplicationContext Instance
        {
            get { return Singleton.instance; }
        }

        private ApplicationContext() { }

        private abstract class Singleton
        {
            static Singleton() { } // DO NOT REMOVE: Static constructor required to prevent beforefieldinit flag from being set
            public static readonly ApplicationContext instance = new ApplicationContext();
        }
        #endregion


  
        public  CultureInfo CurrentCulture {   get; set; }
    }
}
