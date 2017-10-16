using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SANNA.Data.IRepository;
using SANNA.Data.Entities;
namespace TestRepository
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();
            builder.RegisterModule<ContextRepositoryModule>();
            var container = builder.Build();

            var product = container.Resolve<IProductRepository>();


            var data = new Product
            {
                Name = "Ivan"
             };

            product.Insert(data);





        }
    }
}
