using LMS_WEB.Data;
using LMS_WEB.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers
{
    public class SiteAuthorController : Controller
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _appDbContext;

        public SiteAuthorController(
            IAuthorRepository authorRepository,
            IWebHostEnvironment webHostEnvironment,
            AppDbContext appDbContext)
        {

            _authorRepository = authorRepository;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;

        }



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int authorId)
        {
            ViewBag.AuthorId = authorId;

            var authors = await _authorRepository.GetAllAsync(authorId);
            return View(authors);
        }

    }
}
