using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageRestaurantsController : Controller
    {
        // GET: ManageRestaurants
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Restaurants";
            ViewBag.Path = "/ManageRestaurants/Index/";

            return View();
        }
    }
}