using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        SiteProvider provider;

        public HomeController(SiteProvider provider)
        {
            this.provider = provider;
        }

        public IActionResult Index()
        {
            provider.DoSomeThing();
            return View();
        }
    }
}
