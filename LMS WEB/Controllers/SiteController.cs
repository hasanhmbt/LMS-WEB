using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class SiteController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SiteController(
            AppDbContext appDbContext
            )
        {
            _appDbContext = appDbContext;


        }

        public IActionResult Index()
        {
            var books = _appDbContext.VwMostOrderedBooks.ToList();

            return View(books);
        }


        public IActionResult RecommendedBooks()
        {
            var books = _appDbContext.VwMostOrderedBooks.ToList();
            books = books.OrderBy(x => Guid.NewGuid()).ToList();

            var randomBooks = books.Take(3).ToList();


            return View(randomBooks);
        }
    }
}
