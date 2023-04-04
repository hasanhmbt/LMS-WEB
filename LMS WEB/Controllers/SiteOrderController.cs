using LMS_Web.Data;
using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Models.IdentityModels;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Controllers
{
    public class SiteOrderController : Controller
    {

        #region Fields

        private readonly IOperationRepository _operationRepository;
        private readonly AppDbContext _appDbContext;
        private readonly AppIdentityDbContext _appIdentityDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;


        public SiteOrderController(

            IOperationRepository operationRepository,
            AppDbContext appDbContext,
            IWebHostEnvironment webHostEnvironment,
            UserManager<AppUser> userManager,
            AppIdentityDbContext appIdentityDbContext
            )
        {
            _appDbContext = appDbContext;
            _operationRepository = operationRepository;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _appIdentityDbContext = appIdentityDbContext;
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
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AddOrder(SiteOrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            string userId = string.Empty;

            var user = await _userManager.GetUserAsync(this.User);
            if (user != null)
                userId = user.Id;


            var operationId = _appDbContext.Orders.Add(new Order
            {
                BookId = model.BookId,
                UserId = userId

            });
            return RedirectToAction(nameof(Index));

        }
    }
}
