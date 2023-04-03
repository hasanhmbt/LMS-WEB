using LMS_WEB.Models.DbModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IBookCategoryRepository
    {
        Task<List<VwBookCategory>> GetAllAsync(int categoryId,string searchText="");
        Task<List<VwBookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
        int Add(BookCategory category);
        void Edit(BookCategory category, int id);

        void Delete(int id);

    }
}
