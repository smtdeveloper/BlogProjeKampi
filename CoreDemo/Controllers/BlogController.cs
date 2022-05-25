using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
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
  
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var result = bm.GetBlogsListWithCategory();
            return View(result);
        }

        public void GetCategoryList()
        {
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            ViewBag.CommentId = id;
            var result = bm.GetBlogByID(id);
            return View(result);
        }

        public IActionResult GetBlogListByWriter()
        {

            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var result =  bm.GetBlogsListWithWriter(writerId);
            return View(result);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return View();
        }
        
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                var usermail = User.Identity.Name;
                var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
                blog.WriterId = writerId;

                bm.TAdd(blog);
                return RedirectToAction("GetBlogListByWriter", "Blog");    
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

      
        public IActionResult BlogDelete(int id)
        {
            var value =  bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("GetBlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var value = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(value);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {

            blog.Status = true;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

            blog.WriterId = writerId;
            bm.TUpdate(blog);

           
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return RedirectToAction("GetBlogListByWriter");
        }
          
        public IActionResult ChangeStatusBlog(int id)
        {
            var blogValue = bm.TGetById(id);
            if (blogValue.Status)
            {
                blogValue.Status = false;
            }
            else
            {
                blogValue.Status = true;
            }
            bm.TUpdate(blogValue);
            return RedirectToAction("GetBlogListByWriter");
        }



    }
}
