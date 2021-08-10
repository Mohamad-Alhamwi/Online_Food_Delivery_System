using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class FavouritesController : Controller
    {
        // GET: Favourite
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Favourites";
            ViewBag.Path = "/Favourites/Index/";

            return View();
        }
    }
}