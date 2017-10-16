using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Data.Entities
{
    public class Product  : BaseEntity
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }


    }
}
