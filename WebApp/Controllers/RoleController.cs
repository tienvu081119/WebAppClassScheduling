using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RoleController : BaseController
    {
        //RoleRepository repository;

        //public RoleController(CSContext context)
        //{
        //    repository = new RoleRepository(context);
        //}

        public RoleController(SiteProvider provider) : base(provider)
        {

        }

        public IActionResult Index()
        {
            return View(provider.Role.GetRoles());
        }

        [HttpPost]

        public IActionResult Create(Role obj)
        {
            provider.Role.Add(obj);
            return Redirect("/role");
        }
    }
}
