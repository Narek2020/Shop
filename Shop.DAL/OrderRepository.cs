using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Common.Models;

namespace Shop.DAL
{
    public class OrderRepository
    {
        public List<Order> GetProduct()
        {
            var orders = new List<Order>();
            using (var context = new OnlineShopEntities())
            {
                orders = context.Orders.Include("Product").Include("User").AsNoTracking().ToList();
            }

            return orders;
        }

        public void SetOrder(OrderModel order)
        {
            using (var context = new OnlineShopEntities())
            {
              
                context.Orders.Add(new Order
                {
                    userId = order.UserId,
                    productId = order.ProductId,
                    count = order.Count,
                }); 
                context.SaveChanges();
            }
        }

    }
}
