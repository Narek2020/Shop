using Shop.BLL;
using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orders;
    

        public HomeController()
        {
            _userService = new UserService();
            _orders = new OrderService();
        }

        [HttpGet]
        public ActionResult Index()
        {    
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogIN()
        {
            FormsAuthentication.SignOut();

            return View();
        }

        [HttpPost]
        public ActionResult LogIN(UserModel user)
        {

            if (ModelState.IsValid && _userService.GetUsersForLogin(user))
            {
            //    Session["id"] = result;
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {

            if (_userService.CheckUser(user.Email))
            {
                ModelState.AddModelError("LogOnError", "This email address is already being used");
            }

            if(ModelState.IsValid)
            {
                _userService.SetUsers(user);
                return RedirectToAction("LogIN");
            }
            
            return View(user);
        }

        [HttpPost]
        public JsonResult GetOrder(string userName)
        {
            var userOrders = _orders.GetOrder(userName);

            return Json(userOrders);
        }
    }
}