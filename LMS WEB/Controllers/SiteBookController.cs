using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var book = await _appDbContext.Books.ToListAsync();
            
            return View("~/Views/Site/Books.cshtml", book);
        }
    }
}
