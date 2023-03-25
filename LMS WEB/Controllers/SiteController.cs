using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
