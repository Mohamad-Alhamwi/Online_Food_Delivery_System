using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class RestaurantOrdersController : Controller
    {
        // GET: RestaurantOrders
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Restaurant Orders";

            return View();
        }
    }
}