using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
       WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer, string passwordAgain)
        {
            if (  writer.Password == passwordAgain)
            {

                writer.Status = true;
                wm.Add(writer);
                return RedirectToAction("Index", "Blog");
            }

            else
            {
                ModelState.AddModelError("Password", "Girdiğiniz Parola Eşleşmedi, Lütfen Tekrar Deneyin");
            }
            return View();

        }
    }
}
