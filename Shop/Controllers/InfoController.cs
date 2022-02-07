using Shop.BLL;
using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {

            var t = User.Identity.Name;
            ProductService productModel = new ProductService();
            ProductModel product = productModel.GetProductById(id);


            //gtnel model@ ev poxanvel view

            return View(product);
        }

        [HttpPost]
        public ActionResult Index(OrderModel productOrder)
        {
            OrderService order = new OrderService();
            order.SetOrder(productOrder);

            //gtnel model@ ev poxanvel view

            return Json("OK");
        }
    }
}