using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class ProductRepository
    {
        public List<Product> GetProduct()
        {
            var products = new List<Product>();
            using (var context = new OnlineShopEntities())
            {
                products = context.Products.AsNoTracking().ToList();
            }

            return products;
        }

        
    }
}
