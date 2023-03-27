using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LMS_WEB.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IBookCategoryRepository _categoryRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(IBookCategoryRepository bookCategoryRepository, AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _categoryRepository = bookCategoryRepository;
            _environment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int categoryId, string category)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.Category = category;

            var categories = await _categoryRepository.GetAllAsync(categoryId);
            return View(categories);
        }


        [HttpPost]
        public async Task<IActionResult> Index(int categoryId, string searchText, string category)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.Category = category;
            ViewBag.SearchText = searchText;

            var categories = await _categoryRepository.GetAllAsync(categoryId, searchText);
            return View(categories);
        }




        public ActionResult AddCategory(AddOrEditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            int categoryId = _categoryRepository.Add(new BookCategory { Name = model.Name, CategoryDescription = model.CategoryDescription });

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return View(new AddOrEditCategoryViewModel
            {

                Id = category.Id,
                Name = category.Name,
                CategoryDescription = category.CategoryDescription
            });
        }


        [HttpPost]

        public async Task<IActionResult> EditCategory(AddOrEditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);



            _categoryRepository.Edit(new BookCategory { Name = model.Name, CategoryDescription = model.CategoryDescription }, model.Id);

            //TempData["success"] = true;
            //TempData["message"] = "Company saved successfullly";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(int Id)
        {
            _categoryRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
