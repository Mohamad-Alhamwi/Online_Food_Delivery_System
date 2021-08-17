using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;


namespace OnlineFoodOrderingSystem.Controllers
{
    public class ManageCategoriesController : Controller
    {
        // GET: ManageCategories

        public ActionResult Index()
        {
            Model1 m = new Model1();

            List<Category> category = m.Category.ToList();

            ViewBag.SubTitle = "Categories";
            ViewBag.Path = "/ManageCategories/Index/";

            return View(category);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            Category category = new Category();

            return View(category);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            Model1 m = new Model1();
            Category c = m.Category.FirstOrDefault(x => x.id == category.id);

            if (c == null)
            {
                category.created_at = DateTime.Now;
                m.Category.Add(category);
            }
            else
            {
                c.category_name = category.category_name;
                c.catogory_description = category.catogory_description;
                c.updated_at = DateTime.Now;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            Model1 m = new Model1();
            category = m.Category.FirstOrDefault(x => x.id == category.id);
            m.Category.Remove(category);
            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            Model1 m = new Model1();
            Category Category = m.Category.FirstOrDefault(x => x.id == id);
            return View("AddCategory", Category);
        }
    }
}