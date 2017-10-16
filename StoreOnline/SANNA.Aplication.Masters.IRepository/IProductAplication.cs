using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SANNA.Aplication.Masters.Entities;
using SANNA.Comun.Entities.Base;
using SANNA.Cross.Helpers.Enums;

namespace SANNA.Aplication.Masters.IRepository
{
    public interface IProductAplication
    {
        IEnumerable<Product> GetAllProducts(Enumerates.TypeSource source);
        StatusResponse Register(Product entity);
        StatusResponse Update(Product entity);
        StatusResponse Delete(Product entity);
        Product GetProducById(ProductRequest entity);
        IEnumerable<ProductResponse> ProductFilterPagination(ProductRequest entity);
        IEnumerable<Category> ItemsCategory(Enumerates.TypeSource source);
    }
}
