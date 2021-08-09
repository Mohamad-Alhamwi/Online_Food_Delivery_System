using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class MyCardsController : Controller
    {
        // GET: MyCards
        public ActionResult Index()
        {
            return View();
        }
    }
}