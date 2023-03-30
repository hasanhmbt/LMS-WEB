using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS_Web.Data;
using LMS_WEB.Models.IdentityModels;
using LMS_Web.Tools;
using LMS_WEB.ViewModels.IdentityModels;
using LMS_WEB.Tools;

namespace OMS_Web.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly AppIdentityDbContext _identityDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdministrationController(
            AppIdentityDbContext identityDbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _identityDbContext = identityDbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Roles

        public IActionResult Roles()
        {
            var roles = _identityDbContext.VwRoles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(AddOrEditRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _roleManager.CreateAsync(new IdentityRole { Name = model.Name });

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Roles));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(new AddOrEditRoleViewModel { Id = role.Id, Name = role.Name });
        }


        [HttpPost]
        public async Task<IActionResult> EditRole(AddOrEditRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var role = await _roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Roles));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }


        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Roles));
        }

        #endregion


        #region Users

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }

        public IActionResult CreateUser()
        {
            ViewBag.roles = _roleManager.Roles.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(AddOrEditUserViewModel model)
        {
            ViewBag.roles = _roleManager.Roles.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            if (!ModelState.IsValid)
                return View(model);

            if (model.UserImage != null)
            {
                var fileUploadResult = FileOperations.UploadFile(_webHostEnvironment.WebRootPath, "User images", model.UserImage);
                model.ImagePath = fileUploadResult.FilePath;
            }

            string randomPassword = CommonTools.GenerateRandomPassword(7);

            CommonTools.SendEmail(model.Email, "Library acces code", $"Use this credentials to login your new account\nUsername: {model.UserName}\nPassword: {randomPassword}");

            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                ImagePath = model.ImagePath,
                ChangePassword = true
            };

            var result = await _userManager.CreateAsync(user, randomPassword);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);

                await _userManager.AddToRoleAsync(user, role.Name);

                return RedirectToAction(nameof(Users));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }


        public async Task<IActionResult> EditUser(string id)
        {
            ViewBag.roles = _roleManager.Roles.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            var user = await _userManager.FindByIdAsync(id);

            var model = new AddOrEditUserViewModel
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
            {
                string roleName = roles[0];
                var role = _roleManager.Roles.Where(r => r.Name == roleName).FirstOrDefault();
                model.RoleId = role.Id;
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(AddOrEditUserViewModel model)
        {
            ViewBag.roles = _roleManager.Roles.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            if (!ModelState.IsValid)
                return View(model);

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
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Any())
                {
                    string roleName = roles[0];
                    var oldRole = _roleManager.Roles.Where(r => r.Name == roleName).FirstOrDefault();
                    if (model.RoleId != oldRole.Id)
                    {
                        await _userManager.RemoveFromRoleAsync(user, oldRole.Name);

                        var role = await _roleManager.FindByIdAsync(model.RoleId);

                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else
                {
                    var role = await _roleManager.FindByIdAsync(model.RoleId);

                    await _userManager.AddToRoleAsync(user, role.Name);
                }

                return RedirectToAction(nameof(Users));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Users));
        }
        #endregion



       
    }
}
