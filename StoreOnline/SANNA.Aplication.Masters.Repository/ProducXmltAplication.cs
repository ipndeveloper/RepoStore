using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PagedList;
using SANNA.Aplication.Masters.Entities;
using SANNA.Aplication.Masters.IRepository;
using SANNA.Data.IRepository;
using DAT =SANNA.Data.Entities;
namespace SANNA.Aplication.Masters.Repository
{
    public class ProducXmltAplication : IProducXmltAplication
    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProducXmltAplication(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
              var query = _productRepository.Entities.AsEnumerable();
              var result = Mapper.Map<IEnumerable<Product>>(query);
            return result;
        }

        public Product GetProducById(int Id)
        {
            var query = _productRepository.GetById(Id);
            var result = Mapper.Map<Product>(query);
            return result;
        }

        public PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity)
        {
            PagedList<ProductResponse> result = null;
            try
            {

               
                var query = from prod in _productRepository.Entities.AsEnumerable()
                            join cate in _categoryRepository.Entities.AsEnumerable()
                            on prod.IdCategory equals cate.Id
                            where (string.IsNullOrEmpty(entity.Name) || prod.Name == entity.Name) &&
                                  (entity.IdCategory <= 0 || prod.IdCategory == entity.IdCategory)
                            select new ProductResponse
                            {
                                Name = prod.Name,
                                Description = prod.Description,
                                Price = prod.Price,
                                IdCategory = cate.Id,
                                IdProduct = prod.Id,
                                NameCategory = cate.Name
                                
                            };
                //switch (entity.sortOrder)
                //{
                //    case "name_desc":
                //        query = query.OrderByDescending(s => s.Description);
                //        break;
                //    case "Date":
                //        query = query.OrderBy(s => s.IdProduct);
                //        break;

                //    default:  // Name ascending 
                //        query = query.OrderBy(s => s.Name);
                //        break;
                //}

                result = query.ToPagedList(entity.Page, entity.Size) as PagedList<ProductResponse>;

            }
            catch (Exception ex)
            {

            }


            return result;


        }

        public void Register(Product entity)
        {
            _productRepository.Insert(Mapper.Map<DAT.Product>(entity));
        }

        public void Update(Product entity)
        {
            _productRepository.Update(Mapper.Map<DAT.Product>(entity));
        }
    }
}
