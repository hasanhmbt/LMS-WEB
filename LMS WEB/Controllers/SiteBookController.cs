using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace LMS_WEB.Controllers
{
    public class SiteBookController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookCategoryRepository _categoryRepository;

        public SiteBookController(
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int bookId, string book)
        {
            var books = await _bookRepository.GetAllAsync(bookId);
            ViewBag.book = book;
            ViewBag.bookId = bookId;
            
            return View(  books);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int bookId, string book, string searchText)
        {
            var books = await _bookRepository.GetAllAsync(bookId, searchText);
            ViewBag.book = book;
            ViewBag.bookId = bookId;
            ViewBag.SearchText = searchText;

            return View(  book);
        }
    }
}
