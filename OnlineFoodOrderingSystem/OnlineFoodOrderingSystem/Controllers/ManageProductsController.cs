using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageProductsController : Controller
    {
        // GET: ManageProducts
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Products";
            ViewBag.Path = "/ManageProducts/Index/";

            return View();
        }
    }
}