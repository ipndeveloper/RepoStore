using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Data.Entities;

namespace SANNA.Cross.Helpers.Data
{
    public  static class DataMemory
    {
        public static List<Product> ArrayOfProduct()
        {

            return cutomerList;

        }
        public static List<Product> cutomerList = new List<Product>()
        {
                new Product { IdCategory = 1, Name = "Memory Data 1", Description = "Memory Data 1", Price = 123, State = true, Id = 1 }
        };
        public static List<Category> ArrayOfCategory()
        {
           return  new List<Category> {
                    new Category {  Description = "Memory Category 1" , Id =1 , State =true , Name = "Memory Category 1" },
                    new Category {  Description = "Memory Category 2" , Id =1 , State =true , Name = "Memory Category 2" },
                    new Category {  Description = "Memory Category 3" , Id =1 , State =true , Name = "Memory Category 3" }


             };
        }
    }
}
