using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Services.Masters.DataContracts
{
    [DataContract]
    public class ProductResponse
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int IdCategory { get; set; }
        [DataMember]
        public int IdProduct { get; set; }
        [DataMember]
        public string NameCategory { get; set; }
    }
}
