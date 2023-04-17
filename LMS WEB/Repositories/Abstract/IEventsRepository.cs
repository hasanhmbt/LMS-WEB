using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IEventsRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        int Add(Event Event);
        void Edit(Event Event);

        void Delete(int id);

    }
}
