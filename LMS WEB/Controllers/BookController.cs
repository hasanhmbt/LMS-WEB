using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
