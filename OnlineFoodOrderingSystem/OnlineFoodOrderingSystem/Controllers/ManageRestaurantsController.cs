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
            ViewBag.Cuisines = cuisine;

            return View(restaurant);
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
                r.cuisine_id = restaurant.cuisine_id;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteRestaurant(Restaurant restaurant)
        {
            Model1 m = new Model1();
            restaurant = m.Restaurant.FirstOrDefault(x => x.id == restaurant.id);
            m.Restaurant.Remove(restaurant);
            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRestaurant(int id)
        {
            Model1 m = new Model1();

            Restaurant restaurant = m.Restaurant.FirstOrDefault(x => x.id == id);

            List<Cuisine> cuisine = m.Cuisine.ToList();
            ViewBag.Cuisines = cuisine;

            return View("AddRestaurant", restaurant);
        }
    }
}