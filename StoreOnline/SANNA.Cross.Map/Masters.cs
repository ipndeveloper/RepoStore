using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using  APE =SANNA.Aplication.Masters.Entities;
using  DAT =SANNA.Data.Entities;
using DAC = SANNA.Services.Masters.DataContracts;
using PagedList;

namespace SANNA.Cross.Map
{
    public class Masters
    {
        internal static void CreateMaps()
        {



            Mapper.CreateMap<APE.Category, DAC.Category>();
            Mapper.CreateMap<DAC.Category, APE.Category>();
            Mapper.CreateMap<APE.Category, DAT.Category>();
            Mapper.CreateMap<DAT.Category, APE.Category>();


            Mapper.CreateMap<APE.Product, DAC.Product>();
            Mapper.CreateMap<DAC.Product, APE.Product>();


            Mapper.CreateMap<APE.Product, DAT.Product>();
            Mapper.CreateMap<DAT.Product, APE.Product>();

            Mapper.CreateMap<APE.ProductResponse, DAC.ProductResponse>();
            Mapper.CreateMap<DAC.ProductResponse, APE.ProductResponse>();
            

            Mapper.CreateMap<APE.ProductRequest, DAC.ProductRequest>();
            Mapper.CreateMap<DAC.ProductRequest, APE.ProductRequest>();
           


            //Mapper.CreateMap<IEnumerable<APE.ProductResponse>, IEnumerable<DAC.ProductResponse>>();
            //Mapper.CreateMap<IEnumerable<DAC.ProductResponse>, IEnumerable<APE.ProductResponse>>();

            //Mapper.CreateMap<List<APE.ProductResponse>, List<DAC.ProductResponse>>();
            //Mapper.CreateMap<List<DAC.ProductResponse>, List<APE.ProductResponse>>();

            Mapper.CreateMap<PagedList<APE.ProductResponse>, PagedList<DAC.ProductResponse>>().ConvertUsing<PagedListConverter<APE.ProductResponse, DAC.ProductResponse>>(); 
            Mapper.CreateMap<PagedList<DAC.ProductResponse>, PagedList<APE.ProductResponse>>().ConvertUsing<PagedListConverter<DAC.ProductResponse, APE.ProductResponse>>(); 

        }


    }
    public class PagedListConverter<S,T> : ITypeConverter<PagedList<S>, PagedList<T>>
    {
        public PagedList<T> Convert(ResolutionContext context)
        {
            var models = (PagedList<S>)context.SourceValue;
            var viewModels = models.Select(p => Mapper.Map<S, T>(p)).ToList();
            return new PagedList<T>(viewModels.AsQueryable(), models.PageNumber, models.PageSize);
        }
    }

}
