using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SANNA.Aplication.Masters.Entities;

namespace SANNA.Aplication.Masters.IRepository
{
    public interface IProducXmltAplication
    {

        IEnumerable<Product> GetAllProducts();
        void Register(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProducById(int Id);
        PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity);


    }
}
