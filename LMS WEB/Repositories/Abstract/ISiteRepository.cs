using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface ISiteRepository
    {
        int Add(Order order);
        Task<Vworeder> GetByIdAsync(int? id);


    }
}
