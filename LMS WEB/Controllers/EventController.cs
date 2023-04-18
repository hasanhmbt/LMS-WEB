using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels.IdentityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace LMS_WEB.Controllers
{
    public class EventController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IEventsRepository _eventsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext appDbContext,IEventsRepository eventsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _eventsRepository = eventsRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var events = await _eventsRepository.GetAllAsync();

            return View(events);
        }


        public IActionResult AddEvent(AddOrEditEventViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            if (model.EventImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Event", model.EventImage);
                model.ImagePath = fileUploadResult.FilePath;
            }

            int Evnet = _eventsRepository.Add(new Event
            {
                    Name = model.Name,
                    EventDescription = model.EventDescription,
                    ImagePath = model.ImagePath,
                    EventTime = model.EventTime
                    
            });

            return RedirectToAction(nameof(Index));
 
        }


        [HttpGet]
        public async Task<IActionResult> EditEvent(int Id)
        {
            var Event = await _eventsRepository.GetByIdAsync(Id);

            var model = new AddOrEditEventViewModel
            {
                Id = Event.Id,
                Name = Event.Name,
                EventDescription = Event.EventDescription,
                ImagePath = Event.ImagePath,
                EventTime = Event.EventTime
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditEvent(AddOrEditEventViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            if (model.EventImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "Event", model.EventImage);
                model.ImagePath = fileUploadResult.FilePath;
            }

            var Event = await _eventsRepository.GetByIdAsync(model.Id);

            Event.Name = model.Name;
            Event.EventDescription = model.EventDescription;
            Event.EventTime= model.EventTime;
            Event.ImagePath = model.ImagePath;


            _eventsRepository.Edit(Event);
            return RedirectToAction(nameof(Index));
        
        }




        public async Task<IActionResult> DeleteEvent(int Id)
        {
            _eventsRepository.Delete(Id);
            return RedirectToAction(nameof(Index));

        }
    }
}
