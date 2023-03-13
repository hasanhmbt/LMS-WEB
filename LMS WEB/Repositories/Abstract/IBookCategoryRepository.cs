using LMS_WEB.Models.DbModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IBookCategoryRepository
    {
        Task<List<BookCategory>> GetAllAsync();

        Task<BookCategory> GetByIdAsync(int id);
        void Add(BookCategory category);
        void Edit(BookCategory category, int id);

        void Delete(int id);

    }
}
