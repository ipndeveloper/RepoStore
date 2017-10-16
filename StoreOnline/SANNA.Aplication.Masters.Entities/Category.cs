using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Aplication.Masters.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

    }
}
