using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var result = bm.GetBlogsListWithCategory();
            return View(result);
        }

        public IActionResult BlogReadAll(int id)
        {
            var result = bm.GetBlogByID(id);
            return View(result);
        }

    }
}
