using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Repositories.Concrete;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS_WEB.Models;

namespace LMS_WEB.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _appDbContext;

        public AuthorController(
            IAuthorRepository authorRepository,
            IWebHostEnvironment webHostEnvironment,
            AppDbContext appDbContext)
        {

            _authorRepository = authorRepository;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int authorId )
        {   
            ViewBag.AuthorId = authorId;
             
            var authors = await _authorRepository.GetAllAsync(authorId);
            return View(authors);
        }


        [HttpPost]
        public async Task<IActionResult> Index(int authorId, string searchText)
        {
            ViewBag.AuthorId = authorId;
            ViewBag.SearchText = searchText;

            var authors = await _authorRepository.GetAllAsync(authorId, searchText);
            return View(authors);
        }




        public IActionResult AddAuthor(AddOrEditAuthorViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            if (model.AuthorImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Authors", model.AuthorImage);
                model.ImagePath = fileUploadResult.FilePath;
            }

            int authorId = _authorRepository.Add(new Author
            {
                Name = model.Name,
                Surname = model.Surname,
                Birthdate = model.Birthdate,
                Description = model.Description,
                ImagePath = model.ImagePath,
            });

          


            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> EditAuthor(int id)
        {


            var author = await _authorRepository.GetByIdAsync(id);  

            var model = new AddOrEditAuthorViewModel
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Birthdate = author.Birthdate,
                Description = author.Description,
                ImagePath = author.ImagePath,

            };

            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> EditAuthor(AddOrEditAuthorViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            if (model.AuthorImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Authors", model.AuthorImage);
                model.ImagePath = fileUploadResult.FilePath;
            }


            var author = await _authorRepository.GetByIdAsync(model.Id);

            author.Name = model.Name;
            author.Surname = model.Surname;
            author.Birthdate = model.Birthdate;
            author.Description = model.Description;
            author.ImagePath = model.ImagePath;

         
            _authorRepository.Edit(author);

             

            return RedirectToAction(nameof(Index));
        }



       



        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            _authorRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }




    }
}
