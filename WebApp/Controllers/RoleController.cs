using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        RoleRepository repository;

        public RoleController(CSContext context)
        {
            repository = new RoleRepository(context);
        }

        public IActionResult Index()
        {
            return View(repository.GetRoles());
        }

        [HttpPost]

        public IActionResult Create(Role obj)
        {
            repository.Add(obj);
            return Redirect("/role");
        }
    }
}
