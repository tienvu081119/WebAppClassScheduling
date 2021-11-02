using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using System.IO;

namespace WebApp.Controllers
{
    public class GroupController : Controller
    {
        GroupRepository groupRepository;
        ModuleGroupRepository moduleGroupRepository;
        ModuleRepository moduleRepository;
        public GroupController(CSContext context)
        {
            groupRepository = new GroupRepository(context);
            moduleGroupRepository = new ModuleGroupRepository(context);
            moduleRepository = new ModuleRepository(context);
        }


        public IActionResult Index()
        {
            ViewBag.groups = groupRepository.GetGroups();
            return View();
        }


        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            //return Json(f.FileName);
            List<Group> groups = new List<Group>();
            using (StreamReader stream = new StreamReader(f.OpenReadStream()))
            {
                string line = stream.ReadLine();
                while ((line = stream.ReadLine()) != null)
                {
                    string[] a = line.Split(',');
                    groups.Add(new Group {                       
                        Size = short.Parse(a[1])
                    });
                }
            }

            groupRepository.Add(groups);
            return Redirect("/group");
         
        }


        //[HttpPost]
        //public IActionResult Create(Group obj)
        //{
        //    groupRepository.Add(obj);
        //    return Redirect("/group");
        //}

        public IActionResult Detail(int id)
        {           
            return View(groupRepository.GetGroupAndModules(id));
        }
    }
}
