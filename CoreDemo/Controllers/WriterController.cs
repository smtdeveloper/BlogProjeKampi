using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult WriterEdit()
        {
            var result =  wm.TGetById(20);
            return View(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
           
                p.Status = false;
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
             
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
