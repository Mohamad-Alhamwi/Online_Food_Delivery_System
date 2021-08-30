using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ViewModels;


namespace OnlineFoodOrderingSystem.Controllers
{
    public class BasketController : Controller
    {
        [Authorize]
        // GET: Basket
        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Basket> basket = m.Basket.ToList();
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

            // ... TODO: do in in more proper way.
            List<ProductDetails> basketItems = new List<ProductDetails>();

            for (int counter = 0; counter < ProductsLinqQueri.Count; ++ counter)
            {
                for(int j = 0; j < basket.Count; ++ j)
                {
                    if (ProductsLinqQueri[counter].productId == basket[j].id_product)
                    {
                        basketItems.Add(ProductsLinqQueri[counter]);
                    }
                }
            }

            ViewBag.SubTitle = "Basket";

            return View(basketItems);
        }

        [HttpPost]
        public int AddToBasket(Product product)
        {
            Model1 m = new Model1();

            // Using cookies information to get the user id.
            string user_email = HttpContext.User.Identity.Name;
            int user_id = m.User_.FirstOrDefault(x => x.email == user_email).id;

            Basket basketItem = new Basket();

            basketItem.id_product = product.id;
            basketItem.id_user = user_id;

            m.Basket.Add(basketItem);

            try
            {
                m.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}