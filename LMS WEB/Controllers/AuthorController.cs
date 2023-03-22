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

        public AuthorController(IAuthorRepository authorRepository, IWebHostEnvironment webHostEnvironment, AppDbContext appDbContext)
        {
            _authorRepository = authorRepository;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;

        }


        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAllAsync();
            return View(authors);
        }



    
        public IActionResult AddAuthor(AddOrEditAuthorViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            int authorId = _authorRepository.Add(new Author
            {
                Name = model.Name,
                Surname = model.Surname,
                Birthdate = model.Birthdate,
                Description = model.Description
            });

            var authorImages = new List<AuthorImage>();
            List<FileUploadResult> results = new();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
            {
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Authors", model.FormFiles);
            }

            foreach (var result in results)
            {
                authorImages.Add(new AuthorImage { AuthorId = authorId, FileName = result.FileName, FilePath = result.FilePath });
            }

            if (authorImages.Count > 0)
            {
                _appDbContext.AuthorImages.AddRange(authorImages);
                _appDbContext.SaveChanges();
            }

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

            };

            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> EditAuthor(AddOrEditAuthorViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var author = await _authorRepository.GetByIdAsync(model.Id);

            author.Name = model.Name;
            author.Surname = model.Surname;
            author.Birthdate = model.Birthdate;
            author.Description = model.Description;


            _authorRepository.Edit(author);

            var authorImages = new List<AuthorImage>();
            List<FileUploadResult> results = new();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
            {
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Authors", model.FormFiles);
            }

            foreach (var result in results)
            {
                authorImages.Add(new AuthorImage { AuthorId = model.Id, FileName = result.FileName, FilePath = result.FilePath });
            }

            if (authorImages.Count > 0)
            {
                _appDbContext.AuthorImages.AddRange(authorImages);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult AuthorFiles(int id)
        {
            var authorFiles = _appDbContext.AuthorImages.Where(p => p.AuthorId == id).ToList();
            return View(authorFiles);
        }

        public async Task<IActionResult> DeleteAuthorFile(int id)
        {
            var authorFile = await _appDbContext.AuthorImages.FindAsync(id);
            var authorFiles = _appDbContext.AuthorImages.Where(p => p.AuthorId == id).ToList();


            _appDbContext.AuthorImages.Remove(authorFile);
            _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            _authorRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }




    }
}
