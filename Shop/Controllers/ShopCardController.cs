using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    [Authorize]
    public class ShopCardController : Controller
    {
        // GET: ShopCard
        public ActionResult Index()
        {
            return View();
        }
    }
}