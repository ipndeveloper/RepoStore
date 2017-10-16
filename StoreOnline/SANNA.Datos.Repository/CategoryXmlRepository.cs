using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Data.Core;
using SANNA.Data.Entities;
using SANNA.Data.IRepository;

namespace SANNA.Data.Repository
{
    public class CategoryXmlRepository : XmlRepository<Category>, ICategoryXmlRepository
    {
        private readonly IContext _context;

        public CategoryXmlRepository(IContext context) : base(context)
        {
            _context = context;
        }
    }
}
