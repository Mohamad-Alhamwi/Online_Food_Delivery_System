using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ViewModels;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Cuisine> cuisines = m.Cuisine.ToList();
            List<Restaurant> restaurants = m.Restaurant.ToList();

            // LINQ Queri to retrieve restaurants with cuisine names.
            var restaurantsLinqQueri = restaurants.Join(cuisines,
                                          r => r.cuisine_id,
                                          c => c.id,
                                          (restaurant, cuisine) => new RestaurantCuisine    
                                          {
                                              restaurantId = restaurant.id,
                                              restaurantName = restaurant.restaurant_name,
                                              restaurantTown = restaurant.town,
                                              restaurantLogo = restaurant.logo,
                                              cuisineName = cuisine.cuisine_name,
                                          }).ToList();

            ViewBag.SubTitle = "Home";
            ViewBag.Path = "/Home/Index/";
            ViewBag.Cuisines = cuisines;
            ViewBag.Restaurants = restaurantsLinqQueri;

            return View();
        }

        /*[HttpGet]
        public ActionResult DisplayMenusByCuisines(Cuisine cuisine)
        {
            Model1 m = new Model1();

            // Return the restaurants  belonging to that cuisine.
            List<Restaurant> restaurants = m.Restaurant.Where(x => x.cuisine_id == cuisine.id).ToList();

            // Return the products.
            List< List<Product> > products = new List<List<Product>>();

            for (int counter = 0; counter < restaurants.Count; ++ counter)
            {
                products.Add(m.Product.Where(x => x.id_restaurant == restaurants[counter].id).ToList());
            }

            return View(products);
        }*/
    }
}