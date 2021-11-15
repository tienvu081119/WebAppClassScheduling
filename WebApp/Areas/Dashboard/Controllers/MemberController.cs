using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class MemberController :  BaseController
    {
        
        public MemberController(SiteProvider provider) : base(provider)
        {
           
        }
              
        public IActionResult Index(string q)
        {
            List<Member> list;
            if(string.IsNullOrEmpty(q))
            {
                list = provider.Member.GetMembers();
            }
            else
            {
                list = provider.Member.Search(q);
            }
            return View(list);
        }


        public IActionResult Role(string id)
        {
            ViewBag.roles = provider.Role.GetRoleCheckeds(id);
            return View(provider.Member.GetMemberById(id));
        }

        //public IActionResult Index()
        //{
        //    return View(provider.Member.GetMembers());
        //}
        [HttpPost]
        public IActionResult AddRole(MemberInRole obj)
        {
            return Json(provider.MemberInRole.Add(obj));
        }
    }
}
