using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());


        public IActionResult Index(int page = 1)
        {
            var values = cm.TGetAll().ToPagedList(page,3);
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
             ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                category.Status = true;
                cm.TAdd(category);
                return RedirectToAction("CategoryAdd", "Category");    
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

        public IActionResult CategoryPassive(int id)
        {
            var value = cm.TGetById(id);
            value.Status = false;
            cm.TUpdate(value);

            return RedirectToAction("Index");
        }

    }

   

}
