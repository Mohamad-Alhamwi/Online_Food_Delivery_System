﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageUsersController : Controller
    {
        // GET: ManageUsers
        public ActionResult Index()
        {
            ViewBag.SubTitle = "Users";
            ViewBag.Path = "/ManageUsers/Index/";

            return View();
        }
    }
}