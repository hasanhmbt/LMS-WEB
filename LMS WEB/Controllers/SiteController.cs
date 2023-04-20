using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



        public async Task<IActionResult> CategotyFilter(int Id)
        {

            var filteredBooks = await _appDbContext.VwBooks.Where(b => b.AuthorId.Equals(Id)).OrderByDescending(b => b.Id).ToListAsync();
            return View(filteredBooks);

        }

    }
}
