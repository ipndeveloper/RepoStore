using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;
using SANNA.Cross.Helpers.Enums;

namespace SANNA.Aplication.Masters.Entities
{
    public class Product 
        //: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public bool State { get; set; }
        public int Source { get; set; }
     
        //public Enumerates.TypeSource Source { get; set; }

    }
}
