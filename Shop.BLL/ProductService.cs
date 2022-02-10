using Shop.Common.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductModel GetProductById(int productId)
        {
            var products = _productRepository.GetProduct();

            return products.Where(u => u.id == productId).Select(u => new ProductModel
            {
                Id = u.id,
                Name = u.name,
                Price = u.price,
                Currency = u.currency,
                Category = u.category,
                Size = u.size,
                Color = u.color,
                Description = u.description,
                Weight = u.weight,
                Dimention = u.dimention,
                Material = u.material
            }).FirstOrDefault();
        }
        public List<ProductModel> GetProducts()
        {
            var products = _productRepository.GetProduct();

            return products.Select(u => new ProductModel
            {

               Id = u.id,
               Name = u.name,
               Price = u.price,
               Currency =u.currency,
               Category  = u.category,
               Size = u.size,
               Color = u.color,
               Description = u.description,
               Weight = u.weight,
               Dimention = u.dimention,
               Material  = u.material

    }).ToList();
        }

     
    }
}
