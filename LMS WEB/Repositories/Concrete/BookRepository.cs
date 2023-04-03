using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Add(Book book)
        {
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
            return book.Id;
        }

        public void Edit(Book book)
        {
            _appDbContext.Books.Update(book);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id) 
        {
            var book = _appDbContext.Books.Find(id);
            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
        }



        public async Task<List<VwBook>> GetAllAsync(int boookId, string searchText = "")
        {
            if (searchText != null )
                return await _appDbContext.VwBooks.Where(b => b.Name.Contains(searchText)).OrderByDescending(b => b.Id).ToListAsync();
            else
                return await _appDbContext.VwBooks.OrderByDescending(b => b.Id).ToListAsync();
        }

        public async Task<Book>  GetByIdAsync(int? id)
        {
            return await _appDbContext.Books.FindAsync(id);
        }  

    }
}
