using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected SiteProvider provider;

        public BaseController(SiteProvider provider)
        {
            this.provider = provider;
        }
    }
}
