using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LMS_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppFuncContext _appFuncContext;

        public HomeController(AppFuncContext appFuncContext)
        {
            _appFuncContext = appFuncContext;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetChartData(string beginDate, string endDate)
        {
            DashboardData dashboardData = new();

            try
            {
             
                dashboardData.DashboardCounts = _appFuncContext.FncDashboardCounts(beginDate, endDate).FirstOrDefault();

                var mostOrderedBooks = _appFuncContext.FncMostOrderedBooks(beginDate, endDate).ToList();

                dashboardData.MostOrderedBooks = new MostOrderedBookModel
                {
                    BookNames = mostOrderedBooks.Select(b => b.Book).ToList(),

                    OrderCounts = mostOrderedBooks.Select(b => b.OrderCount).ToList()
                };
            }
            catch (Exception)
            { }

            return Json(dashboardData);
        }
    }
}
