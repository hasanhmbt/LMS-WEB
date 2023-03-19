﻿using JetBrains.Annotations;
using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OMS_Web.Models;

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

        public async Task<IActionResult> Index(int categoryId, string category)
        {
            var books = await _bookRepository.GetAllAsync(categoryId);
            ViewBag.Category = category;
            ViewBag.CategoryId = categoryId;

            return View(books);
        }

        [HttpPost]

        public async Task<IActionResult> Index(int categoryId, string category, string searchText)
        {
            var books = await _bookRepository.GetAllAsync(categoryId);
            ViewBag.Category = category;
            ViewBag.CategoryId = categoryId;
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
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return View();
        }


        [HttpPost]

        public ActionResult AddBook(AddOrEditBookViewModel model)
        {
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            if (!ModelState.IsValid)
                return View(model);

            int bookId = _bookRepository.Add(new Book
            {
                Code = model.Code,
                Name = model.Name,
                CategoryId = model.CategoryId,
                AuthorId = model.AuthorId,
                Count = model.BookQuantity
            });

            var bookImages = new List<BookImage>();
            List<FileUploadResult> results = new List<FileUploadResult>();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Books", model.FormFiles);

            foreach (var result in results)
                bookImages.Add(new BookImage { BookId = bookId, FileName = result.FileName, FilePath = result.FilePath });


            if (bookImages.Count > 0)
            {
                _appDbContext.BookImages.AddRange(bookImages);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));


        }




        public async Task<IActionResult> EditBook(int id)
        {
            ViewBag.categories = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.authors = _appDbContext.Authors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            var book = await _bookRepository.GetByIdAsync(id);

            var model = new AddOrEditBookViewModel
            {
                Id = book.Id,
                Code = book.Code,
                Name = book.Name,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                BookQuantity = book.Count

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(AddOrEditBookViewModel model)
        {
            ViewBag.companies = _appDbContext.BookCategories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            if (!ModelState.IsValid)
                return View(model);

            var book = await _bookRepository.GetByIdAsync(model.Id);

            book.Id = model.Id;
            book.Code = model.Code;
            book.Name = model.Name;
            book.AuthorId = model.AuthorId;
            book.CategoryId = model.CategoryId;
            book.Count = model.BookQuantity;

            _bookRepository.Edit(book);

            var bookImages = new List<BookImage>();
            List<FileUploadResult> results = new();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
            {
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Books", model.FormFiles);
            }

            foreach (var result in results)
            {
                bookImages.Add(new BookImage { BookId = model.Id, FileName = result.FileName, FilePath = result.FilePath });
            }

            if (bookImages.Count > 0)
            {
                _appDbContext.BookImages.AddRange(bookImages);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult BookFiles(int id)
        {
            var bookFiles = _appDbContext.BookImages.Where(p => p.BookId == id).ToList();
            return View(bookFiles);
        }

        public async Task<IActionResult> DeleteBookFile(int id)
        {
            var bookFile = await _appDbContext.BookImages.FindAsync(id);
            var bookFiles = _appDbContext.BookImages.Where(p => p.BookId == id).ToList();


            _appDbContext.BookImages.Remove(bookFile);
            _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
