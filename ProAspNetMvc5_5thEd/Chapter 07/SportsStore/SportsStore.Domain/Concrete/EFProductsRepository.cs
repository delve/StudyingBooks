using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductsRepository : IProductsRepository
    {
        private EFDbContext context;

        public EFProductsRepository()
        {
            this.context = new EFDbContext();
        }

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
