using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LMS_WEB.Repositories.Concrete
{
    public class EventsRepository : IEventsRepository
    {

        public readonly AppDbContext _appDbContext;
        public EventsRepository( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }


        public async Task<List<Event>> GetAllAsync()
        {
            return await _appDbContext.Events.ToListAsync();
        }


        public async Task<Event> GetByIdAsync(int Id)
        {
            return await _appDbContext.Events.FindAsync(Id);
        }


        public int Add(Event Envent)
        {
            _appDbContext.Events.Add(Envent);
            _appDbContext.SaveChanges();
            return Envent.Id;
        }

        public void Edit(Event Envent)
        {
            _appDbContext.Events.Update(Envent);
            _appDbContext.SaveChanges();
        }


        public void Delete(int Id)
        {
            //var Event = _appDbContext.Events.Find(Id);
            _appDbContext.Events.Remove(_appDbContext.Events.Find(Id));
            _appDbContext.SaveChanges();

        }

    }
}
