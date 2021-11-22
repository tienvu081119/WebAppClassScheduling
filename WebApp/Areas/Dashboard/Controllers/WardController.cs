using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class WardController : BaseController
    {
        int size = 30;
        public WardController(SiteProvider provider) : base(provider) { }

        public IActionResult Index(int id = 1)
        {
            List<Ward> list = provider.Ward.GetWards(id, size, out int total);
            ViewBag.total = total;
            return View(list);
        }

    }
}
