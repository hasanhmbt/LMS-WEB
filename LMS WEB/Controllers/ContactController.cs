using LMS_Web.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class ContactController : Controller
    {



        [HttpGet]
        public IActionResult Index( )
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            CommonTools.SendEmail("librarycontact2@gmail.com", "User message from contact us", $"User informations \nName:{model.FirstName}\nLastname:{model.LastName}\nEmail:{model.Email}\nPhone Number:{model.PhoneNum}\n\nMessage: {model.Message}");
            return View();
        }
    }
}
