using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LMS_WEB.Repositories.Concrete
{
    public class BookCategoryRepository:IBookCategoryRepository
    {

        private readonly AppDbContext _appDbContext;
        public BookCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<List<VwBookCategory>> GetAllAsync()
        {
            return await _appDbContext.VwBookCategories.ToListAsync();
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            return await _appDbContext.BookCategories.FindAsync(id);
        }


        public int Add(BookCategory category)
        {
            _appDbContext.BookCategories.Add(category);
            _appDbContext.SaveChanges();
            return category.Id;
        }

        public void Edit(BookCategory category, int id)
        {
            var categoryData = _appDbContext.BookCategories.Find(id);
            categoryData.Name = category.Name;

            _appDbContext.BookCategories.Update(categoryData);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _appDbContext.BookCategories.Find(id);
            _appDbContext.BookCategories.Remove(category);
            _appDbContext.SaveChanges();
        }

        

    }
}
