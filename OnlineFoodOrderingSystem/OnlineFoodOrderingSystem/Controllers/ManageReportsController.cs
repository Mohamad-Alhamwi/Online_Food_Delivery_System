﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageReportsController : Controller
    {
        // GET: ManageReports
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Reports";
            ViewBag.Path = "/ManageReports/Index/";

            return View();
        }
    }
}