using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GroupController : Controller
    {
        GroupRepository groupRepository;
        
        public GroupController(CSContext context)
        {
            groupRepository = new GroupRepository(context);                 
        }


        public IActionResult Index()
        {
            ViewBag.groups = groupRepository.GetGroups();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group obj)
        {
            groupRepository.Add(obj);
            return Redirect("/group");
        }
    }
}
