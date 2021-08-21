using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineFoodOrderingSystem.Models;


namespace OnlineFoodOrderingSystem.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User_ user)
        {
            Model1 m = new Model1();

            User_ u = m.User_.FirstOrDefault(x => x.email == user.email && x.pwd == user.pwd);

            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(u.email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = "The email or password is incorrect!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}