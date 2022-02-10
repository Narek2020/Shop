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
        private readonly ProductService _productModel;
        private readonly OrderService _orderService;
        public InfoController()
        {
            _productModel = new ProductService();
            _orderService = new OrderService();
        }
        [HttpGet]
        public ActionResult Index(int id)
        {

            ProductModel product = _productModel.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Index(OrderModel productOrder)
        {
            _orderService.SetOrder(productOrder);

            return Json("OK");
        }
    }
}