using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.ViewModels.IdentityModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace LMS_WEB.Controllers
{
    public class EventController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IEventsRepository _eventsRepository;

        public EventController(AppDbContext appDbContext,IEventsRepository eventsRepository)
        {
            _appDbContext = appDbContext;
            _eventsRepository = eventsRepository;
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

            int Evnet = _eventsRepository.Add(new Event
            {
                    Name = model.Name,
                    EventDescription = model.EventDescription,
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
                EventTime = Event.EventTime
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditEvent(AddOrEditEventViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var Event = await _eventsRepository.GetByIdAsync(model.Id);

            Event.Name = model.Name;
            Event.EventDescription = model.EventDescription;
            Event.EventTime= model.EventTime;

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
