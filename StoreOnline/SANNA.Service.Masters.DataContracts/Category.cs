using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;

namespace SANNA.Services.Masters.DataContracts
{
    [DataContract]
    public class Category  
        //: BaseEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdCategory { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool State { get; set; }
    }
}
