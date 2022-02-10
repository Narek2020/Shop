using Shop.BLL;
using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
   
    public class ProductController : Controller
    {

        private readonly ProductService _productMode;
        public ProductController()
        {
            _productMode = new ProductService();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            List<ProductModel> products = _productMode.GetProducts();

            return View(products);
        }
     
    }
}