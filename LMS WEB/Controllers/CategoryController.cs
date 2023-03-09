using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
