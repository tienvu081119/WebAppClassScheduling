using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    public class AccessDashboardFilter : Attribute, IActionFilter
    {
        SiteProvider provider;
        private Func<SiteProvider> getService;

        public AccessDashboardFilter(SiteProvider provider)
        {
            this.provider = provider;
        }

        public AccessDashboardFilter(Func<SiteProvider> getService)
        {
            this.getService = getService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Controller is Controller controller)
            {
                controller.ViewBag.hello = "Xin Chào các bạn hoc viên";
                if(context.HttpContext.User.Identity.IsAuthenticated)
                {
                    string id = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    controller.ViewBag.accesses = provider.Access.GetAccessesByMemberId(id);
                }

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
                    }
    }
}
