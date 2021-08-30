using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageProductsController : Controller
    {
        // GET: ManageProducts
        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Product> product = m.Product.ToList();

            ViewBag.SubTitle = "Products";
            ViewBag.Path = "/ManageProducts/Index/";

            return View(product);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            Model1 m = new Model1();
            Product product = new Product();

            List<Category> category = m.Category.ToList();
            ViewBag.Categories = category;

            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            Model1 m = new Model1();
            Product p = m.Product.FirstOrDefault(x => x.id == product.id);

            if (p == null)
            {
                product.created_at = DateTime.Now;
                m.Product.Add(product);
            }
            else
            {
                p.product_name = product.product_name;
                p.price = product.price;
                p.product_weight = product.product_weight;
                p.product_description = product.product_description;
                p.category_id = product.category_id;
                p.updated_at = DateTime.Now;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public int DeleteProduct(Product product)
        {
            Model1 m = new Model1();
            product = m.Product.FirstOrDefault(x => x.id == product.id);
            m.Product.Remove(product);

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

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Model1 m = new Model1();
            Product product = m.Product.FirstOrDefault(x => x.id == id);

            List<Category> category = m.Category.ToList();
            ViewBag.Categories = category;

            return View("AddProduct", product);
        }
    }
}