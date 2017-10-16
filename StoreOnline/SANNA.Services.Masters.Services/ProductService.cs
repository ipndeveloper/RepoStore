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
using APE = SANNA.Aplication.Masters.Entities;
using DAC = SANNA.Services.Masters.DataContracts;
using SANNA.Cross.Helpers.Enums;
using SANNA.Comun.Entities.Base;

namespace SANNA.Services.Masters.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductAplication _productAplication;
        public ProductService(IProductAplication productAplication)
        {
            _productAplication = productAplication;
        }
     
        public IEnumerable<Product> GetAllProducts(Enumerates.TypeSource source)
        {
            var query = _productAplication.GetAllProducts(source);
            var result = Mapper.Map<IEnumerable<DAC.Product>>(query);
            return result;
        }

        public Product GetProducById(ProductRequest entity)
        {
           var ent =_productAplication.GetProducById(Mapper.Map<APE.ProductRequest>(entity));
           var result = Mapper.Map<DAC.Product>(ent);
            return result;
        }

        public PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity)
        {
           IEnumerable<APE.ProductResponse> query= _productAplication.ProductFilterPagination(Mapper.Map<APE.ProductRequest>(entity));
            var result = Mapper.Map<IEnumerable<ProductResponse>>(query);

           var paginate = result.ToPagedList(entity.Page, entity.Size);



            //var temp =  result as IPagedList<ProductResponse>;
            return (PagedList<ProductResponse>)paginate; 
        }

        public StatusResponse Register(Product entity)
        {
            return _productAplication.Register(Mapper.Map<APE.Product>(entity));
        }

        public StatusResponse Update(Product entity)
        {
            return _productAplication.Update(Mapper.Map<APE.Product>(entity));
        }
        public StatusResponse Delete(Product entity)
        {
          return  _productAplication.Delete(Mapper.Map<APE.Product>(entity));
        }

        public IEnumerable<Category> ItemsCategory(Enumerates.TypeSource source)
        {
            var query = _productAplication.ItemsCategory(source);
            var result = Mapper.Map<IEnumerable<DAC.Category>>(query);
            return result.Select(x=> new Category { IdCategory = x.Id , Name = x.Name } );
            
          
        }
    }
}
