using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANNA.Comun.Data.Core;
using SANNA.Data.Entities;
using SANNA.Data.IRepository;
using SANNA.Data.Repository;


namespace SANNA.Datos.Repository
{
    public class ProductXmlRepository : XmlRepository<Product> , IProductXmlRepository
    {
        private readonly IContext _context;

        public ProductXmlRepository(IContext context) : base(context)
        {
            _context = context;
        }
    }
}
