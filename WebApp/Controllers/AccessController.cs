using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Area("dashboard")]
    public class AccessController : BaseController
    {
        public AccessController(SiteProvider provider): base(provider)
        {

        }

        [HttpPost]
        public IActionResult DeleteMany(Guid[] ids)
        {
            List<Access> list = new List<Access>(ids.Length);
            foreach (var item in ids)
            {
                list.Add(new Access { Id = item });
            }
            provider.Access.Delete(list);
            return Redirect("/dashboard/access");
        }

        public IActionResult Edit(Guid id)
        {
            Access access = provider.Access.GetAccess(id);
            ViewBag.roles = new SelectList(provider.Role.GetRoles(), "Id", "Name", access.RoleId);
            return View(access);
        }


        [HttpPost]
        public IActionResult Edit(Access obj)
        {
            provider.Access.Edit(obj);
            return Redirect("/dashboard/access");
        }

        public IActionResult Index()
        {
            return View(provider.Access.GetAccesses());
        }

        public IActionResult Create()
        {
            ViewBag.roles = new SelectList(provider.Role.GetRoles(),"Id","Name");
            return View();        
        }

        [HttpPost]
        public IActionResult Create(Access obj)
        {
            provider.Access.Add(obj);
            return Redirect("/dashboard/access");
        }


    }
}
