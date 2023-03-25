using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Repositories.Concrete;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS_WEB.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _appDbContext;


        public ReaderController(
            IReaderRepository readerRepository,
            IWebHostEnvironment webHostEnvironment,
            AppDbContext appContext)
        {
            _readerRepository = readerRepository;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appContext;
        }


        public async Task<IActionResult> Index()
        {

            var readers = await _readerRepository.GetAllAsync();

            return View(readers);

        }




        public IActionResult AddReader(AddOrEditReaderViewModel model)
        {
         
            if (!ModelState.IsValid)
                return View(model);

            int readerId = _readerRepository.Add(new Reader
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNum = model.PhoneNum,
                Password = model.Password,
                CreateDate = model.CreateDate,  
                EmailStatus = true

            }) ;

            var readerImages = new List<ReaderImage>();
            List<FileUploadResult> results = new List<FileUploadResult>();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Readers", model.FormFiles);

            foreach (var result in results)
                readerImages.Add(new ReaderImage { ReaderId = readerId, FileName = result.FileName, FilePath = result.FilePath });


            if (readerImages.Count > 0)
            {
                _appDbContext.ReaderImages.AddRange(readerImages);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> EditReader(int id)
        {


            var reader = await _readerRepository.GetByIdAsync(id);

            var model = new AddOrEditReaderViewModel
            {
                Id = reader.Id,
                Name = reader.Name,
                Email = reader.Email,
                PhoneNum = reader.PhoneNum,
                Password = reader.Password,

            };

            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> EditReader(AddOrEditReaderViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var reader = await _readerRepository.GetByIdAsync(model.Id);

            reader.Name = model.Name;
            reader.Email = model.Email;
            reader.PhoneNum = model.PhoneNum;
            reader.Password = model.Password;



            _readerRepository.Edit(reader);

            var readerImages = new List<ReaderImage>();
            List<FileUploadResult> results = new();

            if (model.FormFiles != null && model.FormFiles.Count > 0)
            {
                results = FileOperations.UploadMultipleFiles(_webHostEnvironment.WebRootPath, "Readers", model.FormFiles);
            }

            foreach (var result in results)
            {
                readerImages.Add(new ReaderImage { ReaderId = model.Id, FileName = result.FileName, FilePath = result.FilePath });
            }

            if (readerImages.Count > 0)
            {
                _appDbContext.ReaderImages.AddRange(readerImages);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult ReaderFiles(int id)
        {
            var readerFiles = _appDbContext.ReaderImages.Where(p => p.ReaderId == id).ToList();
            return View(readerFiles);
        }

        public async Task<IActionResult> DeleteReaderFile(int id)
        {
            var readerFile = await _appDbContext.ReaderImages.FindAsync(id);
            var readerFiles = _appDbContext.ReaderImages.Where(p => p.ReaderId == id).ToList();


            _appDbContext.ReaderImages.Remove(readerFile);
            _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DeleteReader(int Id)
        {
            _readerRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }






    }
}
