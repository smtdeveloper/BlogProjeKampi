using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();

        WriterManager wm = new WriterManager(new EfWriterRepository());

        public WriterController(UserManager<AppUser> signInManager)
        {
            _userManager = signInManager;
        }

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.mailName = usermail;


            var writerName = c.Writers.Where(x => x.Mail == usermail).Select(y => y.Name).FirstOrDefault();
            ViewBag.writerName = writerName;

            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var result = wm.TGetById(writerId);
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangePassword(Writer p)
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> WriterEdit()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();

            // model.username = values.UserName;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.phone = values.PhoneNumber;
            model.mail = values.Email;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> WriterEdit(string PasswordAgain, UserUpdateViewModel model)
        {
            UserManager userManager = new UserManager(new EfUserRepository());


            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            // values.UserName = model.username;
            values.PhoneNumber = model.phone;
            if (model.password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            }
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("WriterEdit", "Writer");


        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddWriterImgDto dto) // model kullan +
        {

            Writer w = new Writer();
            if (dto.Image != null)
            {
                var extension = Path.GetExtension(dto.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                dto.Image.CopyTo(stream);
                w.Image = newImageName;

            }
            w.Mail = dto.Mail;
            w.Name = dto.Name;
            w.Password = dto.Password;
            w.About = dto.About;
            w.Phone = dto.Phone;
            w.City = dto.City;
            w.Gender = dto.Gender;
            w.Status = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

        
        public PartialViewResult WriterNavbarPartial()
        {
            var usermail = User.Identity.Name;
            ViewBag.mailName = usermail;
            var writerName = c.Writers.Where(x => x.Mail == usermail).Select(y => y.Name).FirstOrDefault();
            ViewBag.writerName = writerName;
            return PartialView();
        }

       
        public IActionResult WriterFooterPartial()
        {
            return PartialView();
        }


    }
}
