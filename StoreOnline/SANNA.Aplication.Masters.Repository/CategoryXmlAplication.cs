using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Aplication.Masters.Entities;
using SANNA.Aplication.Masters.IRepository;

namespace SANNA.Aplication.Masters.Repository
{
    public class CategoryXmlAplication : ICategoryXmlAplication
    {

        public CategoryXmlAplication()
        {

        }
        public IEnumerable<Category> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
