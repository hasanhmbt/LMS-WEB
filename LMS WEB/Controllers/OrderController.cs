using LMS_WEB.Data;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class OrderController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            


            return View();
        }
    }
}
