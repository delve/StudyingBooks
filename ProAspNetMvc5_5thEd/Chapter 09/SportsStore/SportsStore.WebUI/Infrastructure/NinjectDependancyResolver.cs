using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependancyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependancyResolver(IKernel kernParam)
        {
            kernel = kernParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //    {
            //        new Product{Name = "Football", Price = 25},
            //        new Product{Name = "Surf board", Price = 179},
            //        new Product{Name = "Running shoes", Price = 95}
            //    });
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductsRepository>().To<EFProductsRepository>();
        }
    }
}