using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class FakeProductRepository /* : IProductRepository */
    {
        public IEnumerable<Product> Products => new List<Product> {
             new Product { Name = "Samsung Galaxy S2", Price = 279 },
             new Product { Name = "Samsung Galaxy S3", Price = 479 },
             new Product { Name = "Samsung Galaxy S4", Price = 495 }
         };
    }
}