using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
  
    public class RegisterController : Controller
    {
       WriterManager wm = new WriterManager(new EfWriterRepository());
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.Cities = GetCityList();
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Writer writer, string passwordAgain)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(writer);
            if (result.IsValid)
            {
                if (writer.Password == passwordAgain)
                {

                    writer.Status = true;
                    wm.TAdd(writer);
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    ModelState.AddModelError("Password", "Girdiğiniz Parola Eşleşmedi, Lütfen Tekrar Deneyin");
                }
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }


        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> list = (from x in GetCity()
                                              select new SelectListItem
                                              {
                                                  Text = x,
                                                  Value = x
                                              }).ToList();
            return list;
        }
        public List<string> GetCity()
        {
            String[] CitiesArray = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            return new List<string>(CitiesArray);
        }

    }
}
