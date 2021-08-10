using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Orders";
            ViewBag.Path = "/Orders/Index/";

            return View();
        }
    }
}