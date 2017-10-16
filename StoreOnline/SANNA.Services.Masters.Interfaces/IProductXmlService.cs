using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SANNA.Services.Masters.DataContracts;

namespace SANNA.Services.Masters.Interfaces
{
    [ServiceContract]
    public interface IProductXmlService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts();
        [OperationContract]
        void Register(Product entity);
        [OperationContract]
        void Update(Product entity);
        [OperationContract]
        void Delete(Product entity);
        [OperationContract]
        Product GetProducById(int Id);
        [OperationContract]
        PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity);
    }
}
