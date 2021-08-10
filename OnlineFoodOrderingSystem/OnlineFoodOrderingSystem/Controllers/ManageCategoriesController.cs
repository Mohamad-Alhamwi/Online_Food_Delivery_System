using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageCategoriesController : Controller
    {
        // GET: ManageCategories
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Categories";
            ViewBag.Path = "/ManageCategories/Index/";

            return View();
        }
    }
}