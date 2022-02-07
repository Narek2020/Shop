using Shop.Common.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL
{
    public class OrderService
    {
        OrderRepository ProductOrder = new OrderRepository();
        public void SetOrder(OrderModel order)
        {
            ProductOrder.SetOrder(order);
        }

        public List<OrderProductModel> GetOrder(string userName)
        {
            var dbProduct = ProductOrder.GetProduct();

            var userOrderedProducts = dbProduct.Where(pr => pr.User.email == userName).Select(pr => new OrderProductModel() { 
            
                UserId = pr.userId,
                UserName = pr.User.email,
                ProductId = pr.productId,
                ProductName = pr.Product.name,
                ProductPrice = pr.Product.price,
                Count = pr.count,
               
            }).ToList();


            return userOrderedProducts;

        }


    }
}
