using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Controllers
{
    public class OrderController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly ISiteRepository _siteRepository;
        public OrderController(AppDbContext appDbContext,ISiteRepository siteRepository )
        {
            _appDbContext=appDbContext;
            _appDbContext = appDbContext;
        }


        public async Task<IActionResult> Index()
        {
            var orders = await _appDbContext.Vworeders.ToListAsync();


            return View(orders);
        }



      

        public IActionResult AcceptOrder(int Id)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            //var order = await _siteRepository.GetByIdAsync(model.Id);
            var order =   _appDbContext.Vworeders.Find(Id);

            order.AcceptStatus = false;

            _appDbContext.Vworeders.Update(order);
            _appDbContext.SaveChanges();
            return View();
        }

    }
}
