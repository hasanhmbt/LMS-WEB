using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_WEB.Controllers
{
    public class SiteOrderController : Controller
    {


        private readonly IBookRepository _bookRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookCategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;


        public SiteOrderController(
            IBookRepository bookRepository,
            AppDbContext appDbContext,
            IWebHostEnvironment webHostEnvironment,
            IBookCategoryRepository bookCategoryRepository,
            IAuthorRepository authorRepository

            )
        {
            _appDbContext = appDbContext;
            _bookRepository = bookRepository;
            _categoryRepository = bookCategoryRepository;
            _webHostEnvironment = webHostEnvironment;
            _authorRepository = authorRepository;
        }

      
    }
}
