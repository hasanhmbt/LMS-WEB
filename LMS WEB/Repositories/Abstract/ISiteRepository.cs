using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface ISiteRepository
    {
        Task<List<BookImage>> GetAllAsync();



    }
}
