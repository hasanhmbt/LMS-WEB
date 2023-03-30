using LMS_Web.Tools;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class ContactController : Controller
    {



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage()
        {
            string randomPassword = CommonTools.GenerateRandomPassword(7);

            //CommonTools.SendEmail(model.Email, "Library acces code", $"Use this credentials to login your new account\nUsername: {model.UserName}\nPassword: {randomPassword}");

            return View();
        }
    }
}
