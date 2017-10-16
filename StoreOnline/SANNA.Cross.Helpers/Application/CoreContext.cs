using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Cross.Helpers.Enums;
namespace SANNA.Cross.Helpers.Application
{
    public static class CoreContext
    {

        public static CultureInfo CurrentCultureInfo
        {
            get
            {
                return ApplicationContext.Instance.CurrentCulture;
            }
           
        }

  
    }
}
