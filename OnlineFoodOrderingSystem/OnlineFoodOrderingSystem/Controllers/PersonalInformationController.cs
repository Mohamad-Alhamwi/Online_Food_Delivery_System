using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class PersonalInformationController : Controller
    {
        // GET: MyInformation
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Personal Information";
            ViewBag.Path = "/PersonalInformation/Index/";

            return View();
        }
    }
}