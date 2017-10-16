using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Comun.Entities.Base
{
    public class StatusResponse
    {
       

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }
        public List<string> Messages { get; set; }
    }
}
