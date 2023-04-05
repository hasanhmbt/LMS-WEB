using JetBrains.Annotations;
using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LMS_WEB.Models;

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
 

        [HttpGet]

        public async Task<IActionResult> Index(int bookId, string book)
        {
            var books = await _bookRepository.GetAllAsync(bookId);
            ViewBag.book = book;
            ViewBag.bookId = bookId;

            return View(books);
        }

        [HttpPost]

        public async Task<IActionResult> Index(int bookId, string book, string searchText)
        {
            var books = await _bookRepository.GetAllAsync(bookId, searchText);
            ViewBag.book = book;
            ViewBag.bookId = bookId;
            ViewBag.SearchText = searchText;

            return View(books);
        }


        public async Task<IActionResult> DeleteBook(int Id)
        {
            _bookRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> AddBook()
        {
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text =c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.Name}-{c.Surname}" }).ToList();

            return View();
        }


        [HttpPost]

        public ActionResult AddBook(AddOrEditBookViewModel model)
        {
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.Name}-{c.Surname}" }).ToList();
           
            if (!ModelState.IsValid)
                return View(model);

            if (model.BookImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Books", model.BookImage);
                model.ImagePath = fileUploadResult.FilePath;
            }

            int bookId = _bookRepository.Add(new Book
            {
                Code = model.Code,
                Name = model.Name,
                CategoryId = model.CategoryId,
                AuthorId = model.AuthorId,
                Count = model.BookQuantity,
                Description =model.Description,
                ImagePath = model.ImagePath,
            });

            return RedirectToAction(nameof(Index));


        }




        public async Task<IActionResult> EditBook(int id)
        {
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.Name}-{c.Surname}" }).ToList();

            var book = await _bookRepository.GetByIdAsync(id);

            var model = new AddOrEditBookViewModel
            {
                Id = book.Id,
                Code = book.Code,
                Name = book.Name,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                BookQuantity = book.Count,
                Description = book.Description,
                ImagePath = book.ImagePath

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(AddOrEditBookViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);

            if (model.BookImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Books", model.BookImage);
                model.ImagePath = fileUploadResult.FilePath;

            }

            var book = await _bookRepository.GetByIdAsync(model.Id);

            book.Id = model.Id;
            book.Code = model.Code;
            book.Name = model.Name;
            book.AuthorId = model.AuthorId;
            book.CategoryId = model.CategoryId;
            book.Count = model.BookQuantity;
            book.Description = model.Description;
            book.ImagePath = model.ImagePath;

            _bookRepository.Edit(book);


            return RedirectToAction(nameof(Index));
        }


         


    }
}
