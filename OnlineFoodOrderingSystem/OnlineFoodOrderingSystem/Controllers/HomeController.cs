using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ViewModels;

namespace OnlineFoodOrderingSystem.Controllers
{
    [AllowAnonymous]
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

        [HttpGet]
        public ActionResult DisplayMenusByCuisines(Cuisine cuisine)
        {
            Model1 m = new Model1();

            List<Product> products = m.Product.ToList();
            List<Restaurant> restaurants = m.Restaurant.ToList();

            // LINQ Queri to retrieve products with details.
            var ProductsLinqQueri = products.Join(restaurants,
                                          p => p.id_restaurant,
                                          r => r.id,
                                          (product, restaurant) => new ProductDetails
                                          {
                                                cuisineId = restaurant.cuisine_id,
                                                restaurantId = product.id_restaurant,
                                                categoryId = product.category_id,
                                                productId = product.id,
                                                restaurantName = restaurant.restaurant_name,
                                                productName = product.product_name,
                                                productDescription = product.product_description,
                                                productPrice = product.price,
                                                productWeight = product.product_weight,
                                                productImage = product.product_image
                                          }).ToList();

            // Getting only the products of restaurants of that cuisine.
            List<ProductDetails> product_details = new List<ProductDetails>();

            for (int counter = 0; counter < ProductsLinqQueri.Count; ++ counter)
            {
                if(ProductsLinqQueri[counter].cuisineId == cuisine.id)
                {
                    product_details.Add(ProductsLinqQueri[counter]);
                }
            }

            ViewBag.ProductsDetails = product_details;
            return View();
        }

        [HttpGet]
        public ActionResult DisplayMenusByRestaurants(Restaurant restaurant)
        {
            Model1 m = new Model1();

            List<Product> products = m.Product.Where(x => x.id_restaurant == restaurant.id).ToList();

            return View(products);
        }
    }
}