using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LMS_WEB.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BookController(IBookRepository bookRepository, AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _bookRepository = bookRepository;
        }

        //public Task<IActionResult> AddBook()
        //{

        //    if(!ModelState.IsValid)
        //    return View();
        //}
    }
}
