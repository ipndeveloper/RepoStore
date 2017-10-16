using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SANNA.Cross.Helpers.Enums;

namespace SANNA.Services.Masters.DataContracts
{
    [DataContract]
    public class ProductRequest
    {
        [DataMember]
        public int IdProduct { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int IdCategory { get; set; }
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int Size { get; set; }
        [DataMember]
        public string sortOrder { get; set; }
        [DataMember]
        public string searchString { get; set; }
        [DataMember]
        public Enumerates.TypeSource Source { get; set; }
    }
}
