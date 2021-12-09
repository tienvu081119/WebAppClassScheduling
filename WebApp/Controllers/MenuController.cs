using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MenuController  : BaseController
    {
        public MenuController(SiteProvider provider) : base(provider) { }

        public IActionResult Index()
        {
            //return View(provider.Category.GetCategories());
            return View(provider.Category.GetParents());
        }

        public IActionResult Multiple()
        {
            List<Category> list = provider.Category.GetCategories();

            List<Category> parents = new List<Category>();
            Dictionary<int, Category> dict = new Dictionary<int, Category>();
            foreach(var item in list)
            {
                dict[item.Id] = item;
                if (item.ParentId != null)
                {
                    int key = item.ParentId.Value;
                    if (dict[key].Children is null)
                    {
                        dict[key].Children = new List<Category>();
                    }
                    dict[key].Children.Add(item);
                }
                else
                {
                    parents.Add(item);
                }
            }
            return View(parents);
        }
    }
}
