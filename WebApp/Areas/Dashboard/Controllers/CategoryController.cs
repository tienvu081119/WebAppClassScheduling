

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class CategoryController : BaseController
    {
        public CategoryController(SiteProvider provider) : base(provider) { }

        public IActionResult Edit(int id)
        {
            Category obj = provider.Category.GetCategoryById(id);
            ViewBag.categories = new SelectList(provider.Category.GetCategories(), "Id", "Name", obj.ParentId);
            return View(obj);
        }

        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            provider.Category.Edit(obj);
            return Redirect("/dashboard/category");
        }


        public IActionResult Index()
        {
            return View(provider.Category.GetCategories());
        }

        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(provider.Category.GetCategories(),"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            provider.Category.Add(obj);
            return Redirect("/dashboard/category");
        }
    }
}
