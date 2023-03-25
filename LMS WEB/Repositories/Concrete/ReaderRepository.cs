using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories.Concrete
{
    public class ReaderRepository:IReaderRepository
    {

        private readonly AppDbContext _appDbContext;
        public ReaderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<List<Reader>> GetAllAsync()
        {
            return await _appDbContext.Readers.ToListAsync();
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            return await _appDbContext.Readers.FindAsync(id);
        }


        public int Add(Reader reader)
        {
            _appDbContext.Readers.Add(reader);
            _appDbContext.SaveChanges();
            return reader.Id;
        }

        public void Edit(Reader reader)
        {

            _appDbContext.Readers.Update(reader);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var reader = _appDbContext.Readers.Find(id);
            _appDbContext.Readers.Remove(reader);
            _appDbContext.SaveChanges();
        }




    }
}
