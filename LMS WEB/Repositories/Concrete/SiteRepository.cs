using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories.Concrete
{
    public class SiteRepository:ISiteRepository
    {
        private readonly AppDbContext _appDbContext;

        public SiteRepository(AppDbContext appDbContext)
        {
             _appDbContext = appDbContext;
        }


        //public async Task<List<BookImage>> GetAllAsync()
        //{
        //    return await _appDbContext.BookImages.ToListAsync();
        //}

    }
}
