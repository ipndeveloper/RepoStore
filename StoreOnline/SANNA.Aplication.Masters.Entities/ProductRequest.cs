using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Cross.Helpers.Enums;

namespace SANNA.Aplication.Masters.Entities
{
    public class ProductRequest
    {

        public string Name { get; set; }
        public int IdCategory { get; set; }
        public int IdProduct { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public string sortOrder { get; set; }
        public Enumerates.TypeSource Source { get; set; }
        
    }
}
