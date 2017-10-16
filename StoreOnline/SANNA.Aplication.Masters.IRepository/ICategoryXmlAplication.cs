using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Aplication.Masters.Entities;

namespace SANNA.Aplication.Masters.IRepository
{
    public interface ICategoryXmlAplication
    {
        IEnumerable<Category> GetAllCategory();
        Category GetCategoryById(int Id);
    }
}
