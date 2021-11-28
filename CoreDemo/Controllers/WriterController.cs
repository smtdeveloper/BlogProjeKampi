using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
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
            var result = wm.TGetById(1);
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangePassword(Writer p )
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEdit()
        {
            var result =  wm.TGetById(1);
            return View(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEdit(Writer p, string passwordAgain)
        {
           
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid && p.Password == passwordAgain  )
            {
                

                p.Status = true;
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult WriterNavbarPartial()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult WriterFooterPartial()
        {
            return View();
        }
    }
}
