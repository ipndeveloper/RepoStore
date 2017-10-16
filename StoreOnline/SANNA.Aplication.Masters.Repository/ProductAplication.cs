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
using DAT = SANNA.Data.Entities;
using SANNA.Cross.Helpers.Enums;
using SANNA.Comun.Entities.Base;

namespace SANNA.Aplication.Masters.Repository
{
    public class ProductAplication : IProductAplication
    {

        private readonly IProductXmlRepository _productXmlRepository;
        private readonly ICategoryXmlRepository _categoryXmlRepository;
        private readonly IProductMemoryRepository _productMemoryRepository;
        private readonly ICategoryMemoryRepository _categoryMemoryRepository;

        public ProductAplication(IProductXmlRepository productXmlRepository, ICategoryXmlRepository categoryXmlRepository, IProductMemoryRepository productMemoryRepository, ICategoryMemoryRepository categoryMemoryRepository)
        {
            _productXmlRepository = productXmlRepository;
            _categoryXmlRepository = categoryXmlRepository;
            _categoryMemoryRepository = categoryMemoryRepository;
            _productMemoryRepository = productMemoryRepository;
        }


        public IEnumerable<Product> GetAllProducts(Enumerates.TypeSource source)
        {
            IEnumerable<DAT.Product> query = new List<DAT.Product>();
            if (Enumerates.TypeSource.XmlSource.Equals(source))
            {
                query = _productXmlRepository.Entities.AsEnumerable();
            }
            else if (Enumerates.TypeSource.MemorySource.Equals(source))
            {
                query = _productMemoryRepository.Entities.AsEnumerable();
            }

            var result = Mapper.Map<IEnumerable<Product>>(query);
            return result;
        }

        public Product GetProducById(ProductRequest entity)
        {
            DAT.Product product = new DAT.Product();

            if (Enumerates.TypeSource.XmlSource.Equals(entity.Source))
            {
                product = _productXmlRepository.GetById(entity.IdProduct);
            }
            else if (Enumerates.TypeSource.MemorySource.Equals(entity.Source))
            {
                product = _productMemoryRepository.GetById(entity.IdProduct);
            }
            var result = Mapper.Map<Product>(product);
            return result;
        }

      
        //public PagedList<ProductResponse> ProductFilterPagination(ProductRequest entity)
        //{
        //    PagedList<ProductResponse> result = null;
        //    IEnumerable<ProductResponse> query = null;
        //    try
        //    {

        //        if (Enumerates.TypeSource.XmlSource.Equals(entity.Source))
        //        {
        //            query = GetXmlQuery(entity);
        //        }
        //        else if (Enumerates.TypeSource.MemorySource.Equals(entity.Source))
        //        {
        //            query = GetMemoryQuery(entity);
        //        }

     

        //        result = query.ToPagedList(entity.Page, entity.Size) as PagedList<ProductResponse>;

        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    return result;


        //}


        public IEnumerable<ProductResponse> ProductFilterPagination(ProductRequest entity)
        {
            IEnumerable<ProductResponse> result = null;
            IEnumerable<ProductResponse> query = null;
            try
            {

                if (Enumerates.TypeSource.XmlSource.Equals(entity.Source))
                {
                    query = GetXmlQuery(entity);
                }
                else if (Enumerates.TypeSource.MemorySource.Equals(entity.Source))
                {
                    query = GetMemoryQuery(entity);
                }



                result = query;

            }
            catch (Exception ex)
            {

            }


            return result.ToList();


        }
        private IEnumerable<ProductResponse> GetXmlQuery(ProductRequest entity)
        {
            var query = from prod in _productXmlRepository.Entities
                        join cate in _categoryXmlRepository.Entities
                        on prod.IdCategory equals cate.Id
                        where (string.IsNullOrEmpty(entity.Name) || prod.Name.StartsWith(entity.Name)) &&
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
            return query;
        }
        private IQueryable<ProductResponse> GetMemoryQuery(ProductRequest entity)
        {
            var query = from prod in _productMemoryRepository.Entities
                        join cate in _productMemoryRepository.Entities
                        on prod.IdCategory equals cate.Id
                        where (string.IsNullOrEmpty(entity.Name) || prod.Name.StartsWith(entity.Name)) &&
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
            return query;
        }
        public StatusResponse Register(Product entity)
        {

            try
            {
                Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                if (Enumerates.TypeSource.XmlSource.Equals(Source))
                {
                    _productXmlRepository.Insert(Mapper.Map<DAT.Product>(entity));
                }
                else if (Enumerates.TypeSource.MemorySource.Equals(Source))
                {
                    _productMemoryRepository.Insert(Mapper.Map<DAT.Product>(entity));
                }

                return new StatusResponse { Message = "Correct Register", Success = true };
            }
            catch (Exception ex)
            {
                return new StatusResponse { Message = "Error Register", Success = false };
            }

        }
        public StatusResponse Update(Product entity)
        {
            try
            {
                Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                if (Enumerates.TypeSource.XmlSource.Equals(Source))
                {
                    _productXmlRepository.Update(Mapper.Map<DAT.Product>(entity));
                }
                else if (Enumerates.TypeSource.MemorySource.Equals(Source))
                {
                    _productMemoryRepository.Update(Mapper.Map<DAT.Product>(entity));
                }

              
                return new StatusResponse { Message = "Correct Update", Success = true };
            }
            catch(Exception ex)
            {
                return new StatusResponse { Message = "Error Update", Success = false };
            }
           
        }
        public StatusResponse Delete(Product entity)
        {
            try
            {
                Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                if (Enumerates.TypeSource.XmlSource.Equals(Source))
                {
                    _productXmlRepository.Delete(Mapper.Map<DAT.Product>(entity));
                }
                else if (Enumerates.TypeSource.MemorySource.Equals(Source))
                {
                    _productMemoryRepository.Delete(Mapper.Map<DAT.Product>(entity));
                }
                return new StatusResponse { Message = "Correct Delete", Success = true };
            }
            catch (Exception ex)
            {
                return new StatusResponse { Message = "Error Delete", Success = false };
            }
        }

        public IEnumerable<Category> ItemsCategory(Enumerates.TypeSource source)
        {

            IEnumerable<DAT.Category> query = new List<DAT.Category>();
            if (Enumerates.TypeSource.XmlSource.Equals(source))
            {
                
                query = _categoryXmlRepository.Entities.AsEnumerable();
            }
            else if (Enumerates.TypeSource.MemorySource.Equals(source))
            {
                query = _categoryMemoryRepository.Entities.AsEnumerable();
            }
            var result = Mapper.Map<IEnumerable<Category>>(query);
            return result;
        }
    }
}
