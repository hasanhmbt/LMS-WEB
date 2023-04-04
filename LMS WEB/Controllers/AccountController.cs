using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LMS_WEB.Models.IdentityModels;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using LMS_WEB.ViewModel;
using LMS_Web.Tools;
using LMS_WEB.ViewModels.IdentityModels;

namespace LMS_Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment webHostEnvironment,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, [FromQuery] string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);

                    if (user.ChangePassword)
                        return RedirectToAction(nameof(ChangePassword));

                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("Index", "Home");
                        else if (await _userManager.IsInRoleAsync(user, "Operator"))
                        {
                            return RedirectToAction("Index", "Book");

                        }
                        else
                        {
                            return RedirectToAction("Index", "Site");

                        }
                    }
                    else
                        return Redirect(returnUrl);
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View();
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.User);
                var result = await _userManager.ChangePasswordAsync(user, model.OneTimePassword, model.NewPassword);

                if (result.Succeeded)
                {
                    user.ChangePassword = false;
                    await _userManager.UpdateAsync(user);

                    return RedirectToAction(nameof(Login));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        [HttpGet]
        public async Task<IActionResult> Profile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var model = new ProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                ImagePath = user.ImagePath
            };

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Any())
                model.Role = roles[0];

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SaveProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserImage != null)
                {
                    var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "User images", model.UserImage);
                    model.ImagePath = fileUploadResult.FilePath;
                }

                var user = await _userManager.FindByIdAsync(model.Id);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.ImagePath = model.ImagePath;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["success"] = true;
                    TempData["message"] = "Your information saved successfullly";

                    return RedirectToAction(nameof(Profile), new { id = user.Id });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var currentUser = await _userManager.FindByIdAsync(model.Id);
            var roles = await _userManager.GetRolesAsync(currentUser);

            if (roles.Any())
                model.Role = roles[0];

            return View("Profile", model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {


            string randomPassword = CommonTools.GenerateRandomPassword(7);

            CommonTools.SendEmail(model.Email, "Library acces code", $"Use this credentials to login your new account\nUsername: {model.UserName}\nPassword: {randomPassword}");

            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                ChangePassword = true,


            };

            var result = await _userManager.CreateAsync(user, randomPassword);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);

                await _userManager.AddToRoleAsync(user, role.Name = "Reader");

                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

    }
}
