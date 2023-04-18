using LMS_WEB.Data;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class SiteEventController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SiteEventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var Events = _appDbContext.Events.ToList();

            return View(Events);
        }
    }
}
