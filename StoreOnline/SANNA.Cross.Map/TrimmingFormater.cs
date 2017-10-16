using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Cross.Map
{
    public class TrimmingFormater : AutoMapper.IValueFormatter
    {
        public string FormatValue(AutoMapper.ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            return ((string)context.SourceValue).Trim();
        }
    }
}
