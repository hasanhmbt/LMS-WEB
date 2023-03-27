using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IBookRepository
    {

        Task<List<VwBook>> GetAllAsync(int bookId, string searchText = "");

        Task<Book> GetByIdAsync(int? id);
        int Add(Book book);
        void Edit(Book book);

        void Delete(int id);


    }
}
