using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IBookRepository
    {

        Task<List<VwBook>> GetAllAsync(int companyId, string searchText = "");

        Task<Book> GetByIdAsync(int? id);
        int Add(Book product);
        void Edit(Book product);

        void Delete(int id);


    }
}
