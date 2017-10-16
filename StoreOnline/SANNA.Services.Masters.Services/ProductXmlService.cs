using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PagedList;
using SANNA.Aplication.Masters.IRepository;
using SANNA.Services.Masters.DataContracts;
using SANNA.Services.Masters.Interfaces;
using  APE =SANNA.Aplication.Masters.Entities;
using  DAC = SANNA.Services.Masters.DataContracts;



namespace SANNA.Services.Masters.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class ProductXmlService : IProductXmlService
    {
        private readonly IProducXmltAplication _producXmltAplication;
        public ProductXmlService (IProducXmltAplication producXmltAplication)
        {
            _producXmltAplication = producXmltAplication;
        }
        public void Delete(Product entity)
        {
            _producXmltAplication.Delete(Mapper.Map<APE.Product>(entity));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = _producXmltAplication.GetAllProducts();
            var result = Mapper.Map<IEnumerable<DAC.Product>>(query);
            return result;
        }

        public Product GetProducById(int Id)
        {
            throw new NotImplementedException();
        }

        public PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity)
        {
           var query =  _producXmltAplication.ProductFilterPagination(Mapper.Map<APE.ProductRequest>(entity)) as PagedList<APE.ProductResponse>;
         
           





           var result = Mapper.Map<PagedList<ProductResponse>>(query);
           //var temp =  result as IPagedList<ProductResponse>;
            return result;
        }

        public void Register(Product entity)
        {
            _producXmltAplication.Register(Mapper.Map<APE.Product>(entity));
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
