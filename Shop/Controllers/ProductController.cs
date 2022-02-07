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

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
           
            ProductService productModel = new ProductService();
            List<ProductModel> products = productModel.GetProducts();

            return View(products);
        }
     
    }
}