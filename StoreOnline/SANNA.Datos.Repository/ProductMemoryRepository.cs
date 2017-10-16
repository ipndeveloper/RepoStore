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
    public class ProductMemoryRepository : MemoryRepository<Product>, IProductMemoryRepository
    {
        private readonly IContextMemory _context;

        public ProductMemoryRepository(IContextMemory context) : base(context)
        {
            _context = context;
        }
    }
}
