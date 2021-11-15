using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    [ServiceFilter(typeof(AccessDashboardFilter))]
    public class HomeController : BaseController
    {
        public HomeController(SiteProvider provider): base(provider)
        {

        }

        public IActionResult Index()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Access> accesses = provider.Access.GetAccessesByMemberId(id);
            ViewBag.accesses = accesses;
            return View();
        }
    }
}
