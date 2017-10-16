using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Cross.Helpers.Enums
{
    public class Enumerates
    {
        [DataContract(Name = "TypeSource")]
        public enum TypeSource
        {
            [EnumMember]
            //[Display(Name = "Source Data XML")]
          
            XmlSource =1 ,
            [EnumMember]
            //[Display(Name = "Source Data Memory")]
            
            MemorySource = 2
        }
    }
}
