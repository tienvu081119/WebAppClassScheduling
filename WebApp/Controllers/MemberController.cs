using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MemberController : Controller
    {
        MemberRepository repository;
        RoleRepository roleRepository;
        MemberInRoleRepository memberInRoleRepository;
        public MemberController(CSContext context)
        {
            repository = new MemberRepository(context);
            roleRepository = new RoleRepository(context);
            memberInRoleRepository = new MemberInRoleRepository(context);
        }

        public IActionResult Role(string id)
        {
            ViewBag.roles = roleRepository.GetRoleCheckeds(id);
            return View(repository.GetMemberById(id));
        }

        public IActionResult Index()
        {
            return View(repository.GetMembers());
        }
        [HttpPost]
        public IActionResult AddRole(MemberInRole obj)
        {
            return Json(memberInRoleRepository.Add(obj));
        }
    }
}
