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

 


        public int Add(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
            return order.Id;
        }



        public async Task<Vworeder> GetByIdAsync(int? Id)
        {
            return await _appDbContext.Vworeders.FindAsync(Id);
        }

    }
}
