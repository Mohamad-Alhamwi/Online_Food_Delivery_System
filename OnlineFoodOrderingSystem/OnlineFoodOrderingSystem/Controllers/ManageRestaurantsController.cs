using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;


namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageRestaurantsController : Controller
    {
        // GET: ManageRestaurants
        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Restaurant> restaurant = m.Restaurant.ToList();

            ViewBag.SubTitle = "Restaurants";
            ViewBag.Path = "/ManageRestaurants/Index/";

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            Model1 m = new Model1();

            Restaurant restaurant = new Restaurant();
            List<Cuisine> cuisine = m.Cuisine.ToList();

            ViewBag.SubTitle = "Restaurants";
            ViewBag.Path = "/ManageRestaurants/Index/";
            ViewBag.Restaurant = restaurant;
            ViewBag.Cuisines = cuisine;

            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant)
        {
            Model1 m = new Model1();
            Restaurant r = m.Restaurant.FirstOrDefault(x => x.id == restaurant.id);

            if (r == null)
            {
                m.Restaurant.Add(restaurant);
            }
            else
            {
                r.restaurant_name = restaurant.restaurant_name;
                r.city = restaurant.city;
                r.town = restaurant.town;
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