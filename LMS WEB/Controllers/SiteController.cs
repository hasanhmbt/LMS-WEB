using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class SiteController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookCategoryRepository _categoryRepository;

        public SiteController(
            IBookRepository bookRepository,
            AppDbContext appDbContext,
            IWebHostEnvironment webHostEnvironment,
            IBookCategoryRepository bookCategoryRepository
            )
        {
            _appDbContext = appDbContext;
            _bookRepository = bookRepository;
            _categoryRepository = bookCategoryRepository;
            _webHostEnvironment = webHostEnvironment;


        }

        public IActionResult Index()
        {
            var books = _appDbContext.VwMostOrderedBooks.ToList();

            return View(books);
        }
    }
}
