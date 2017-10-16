using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Aplication.Masters.Entities
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public int IdProduct { get; set; }
        public string NameCategory { get; set; }
    }
}
