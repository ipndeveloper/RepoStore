using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SANNA.Comun.Entities.Base;
using SANNA.Cross.Helpers.Enums;
using SANNA.Services.Masters.DataContracts;

namespace SANNA.Services.Masters.Interfaces
{
    [ServiceContract]
    [ServiceKnownType(typeof(Enumerates.TypeSource))]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts(Enumerates.TypeSource source);
        [OperationContract]
        StatusResponse Register(Product entity);
        [OperationContract]
        StatusResponse Update(Product entity);
        [OperationContract]
        StatusResponse Delete(Product entity);
        [OperationContract]
        Product GetProducById(ProductRequest entity);
        [OperationContract]
        PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity);
        [OperationContract]
        IEnumerable<Category> ItemsCategory(Enumerates.TypeSource source);
    }
}
