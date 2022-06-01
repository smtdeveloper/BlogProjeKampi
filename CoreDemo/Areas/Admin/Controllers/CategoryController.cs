
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
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
            var values = cm.TGetAll().ToPagedList(page,5);
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

        public IActionResult ChangeStatusCategory(int id)
        {
            var value = cm.TGetById(id);
            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            cm.TUpdate(value);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = cm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            category.Status = true;
            cm.TUpdate(category);
            return RedirectToAction("Index");
        }

    }

   

}
