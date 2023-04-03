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
                //cards
                dashboardData.DashboardCounts = _appFuncContext.FncDashboardCounts(beginDate, endDate).FirstOrDefault();
            }
            catch (Exception)
            { }

            return Json(dashboardData);
        }
    }
}
