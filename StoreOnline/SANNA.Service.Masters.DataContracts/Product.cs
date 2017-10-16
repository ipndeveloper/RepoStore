using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Entities.Base;
using SANNA.Cross.Helpers.Enums;

namespace SANNA.Services.Masters.DataContracts
{

    [DataContract]
    //[ServiceKnownType(typeof(Enumerates.TypeSource))]
    [System.Data.Services.IgnoreProperties("Source")]
    public class Product
        //: BaseEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [DataMember]
         [Required(ErrorMessage = "Category is required")]
        public int IdCategory { get; set; }
        [DataMember]
        public bool State { get; set; }
       
        [DataMember]
        //[EnumDataType(typeof(Enumerates.TypeSource), ErrorMessage = "MaritalStatus - must be a valid value.")]

        public int Source { get; set; }
        //public Enumerates.TypeSource Source { get; set; }
    }
}
