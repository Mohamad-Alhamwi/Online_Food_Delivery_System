using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageCuisinesController : Controller
    {
        // GET: ManageCuisines
        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Cuisine> cuisines = m.Cuisine.ToList();

            ViewBag.SubTitle = "Cuisines";
            ViewBag.Path = "/ManageCuisines/Index/";
            return View(cuisines);
        }

        [HttpGet]
        public ActionResult AddCuisine()
        {
            Cuisine cuisine = new Cuisine();

            return View(cuisine);
        }

        [HttpPost]
        public ActionResult AddCuisine(Cuisine cuisine)
        {
            Model1 m = new Model1();
            Cuisine c = m.Cuisine.FirstOrDefault(x => x.id == cuisine.id);

            if (c == null)
            {
                m.Cuisine.Add(cuisine);
            }
            else
            {
                c.cuisine_name = cuisine.cuisine_name;
                c.cuisine_image = cuisine.cuisine_image;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCuisine(Cuisine cuisine)
        {
            Model1 m = new Model1();
            cuisine = m.Cuisine.FirstOrDefault(x => x.id == cuisine.id);
            m.Cuisine.Remove(cuisine);
            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCuisine(int id)
        {
            Model1 m = new Model1();
            Cuisine cuisine = m.Cuisine.FirstOrDefault(x => x.id == id);
            return View("AddCuisine", cuisine);
        }
    }
}