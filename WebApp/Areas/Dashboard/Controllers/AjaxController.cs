using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class AjaxController : BaseController
    {
        public AjaxController(SiteProvider provider) : base(provider) { }

        public IActionResult Index()
        {
            ViewBag.provinces = new SelectList(provider.Province.GetProvinces(),"Id","Name");
            return View();
        }

        public IActionResult GetDistricts(string id)
        {
            return Json(provider.District.GetDistrictsByProvince(id));
        }

        public IActionResult GetWards(string id)
        {
            return Json(provider.Ward.GetWardsByDistrict(id));
        }
    }
}
