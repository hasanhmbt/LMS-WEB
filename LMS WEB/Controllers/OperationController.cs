﻿using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Abstract;
using LMS_WEB.Repositories.Concrete;
using LMS_WEB.Tools;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;
using LMS_WEB.Models.IdentityModels;

namespace LMS_WEB.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperationRepository _operationRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;


        public OperationController(

            IOperationRepository operationRepository,
            AppDbContext appDbContext,
            IWebHostEnvironment webHostEnvironment,
            UserManager<AppUser> userManager
            )
        {
            _appDbContext = appDbContext;
            _operationRepository = operationRepository;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            var operation = await _operationRepository.GetAllAsync();

            return View(operation);
        }




        public async Task<IActionResult> AddOperation()
        {
            ViewBag.Books = _appDbContext.Books.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.Readers = _appDbContext.Readers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOperation(AddOrEditOperationViewModel model)
        {
            ViewBag.Books = _appDbContext.Books.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.Readers = _appDbContext.Readers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            if (!ModelState.IsValid)
                return View(model);
            string userId = string.Empty;
            var user = await _userManager.GetUserAsync(this.User);
            if (user != null)
                userId = user.Id;
            int operationId = _operationRepository.Add(new Operation
            {
                BookId = model.BookId,
                ReaderId = model.ReaderId,
                UserId = userId,
                OrderedBooks = +1

            });


            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> EditOperation(int id)
        {
            ViewBag.Books = _appDbContext.Books.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.Readers = _appDbContext.Readers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            var book = await _operationRepository.GetByIdAsync(id);

            var model = new AddOrEditOperationViewModel
            {
                ReaderId = book.ReaderId,
                BookId = book.BookId,


            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOperation(AddOrEditOperationViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);

            var operation = await _operationRepository.GetByIdAsync(model.Id);

            operation.ReaderId = model.ReaderId;
            operation.BookId = model.BookId;



            _operationRepository.Edit(operation);


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteOperation(int Id)
        {
            _operationRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }


    }

}
