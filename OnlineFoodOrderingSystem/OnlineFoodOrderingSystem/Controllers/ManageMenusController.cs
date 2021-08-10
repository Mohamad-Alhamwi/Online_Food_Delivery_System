﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageMenusController : Controller
    {
        // GET: ManageMenus
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Menus";
            ViewBag.Path = "/ManageMenus/Index/";

            return View();
        }
    }
}