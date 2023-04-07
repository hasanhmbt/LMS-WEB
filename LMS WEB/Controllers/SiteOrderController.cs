using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Models.IdentityModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Controllers
{
    public class SiteOrderController : Controller
    {

        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly ISiteRepository _siteRepository;

        public SiteOrderController(
            AppDbContext appDbContext,
            UserManager<AppUser> userManager,
            ISiteRepository siteRepository
            )
        {
            _userManager = userManager;
            _siteRepository = siteRepository;
            _appDbContext = appDbContext;
        }
        #endregion

        

        [HttpGet]
        public async Task<IActionResult> Index(string Id)
        {
           
             var order = await _appDbContext.Vworeders.Where(b => b.UserId.Contains(Id)).OrderByDescending(b => b.UserId).ToListAsync();


            return View(order);
        }

        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var order = _appDbContext.Orders.Find(Id);
            _appDbContext.Orders.Remove(order);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "SiteBook");

        }


        public async Task<IActionResult> AddOrder(int Id )
        {
            //if (!ModelState.IsValid)
            //    return View(model);


            string userId = string.Empty;

            var user = await _userManager.GetUserAsync(this.User);
            if (user != null)
                userId = user.Id;


            int order = _siteRepository.Add(new Order
            {
                BookId = Id,
                UserId = userId

            });
            return RedirectToAction("Index", "SiteBook");

        }
    }
}
