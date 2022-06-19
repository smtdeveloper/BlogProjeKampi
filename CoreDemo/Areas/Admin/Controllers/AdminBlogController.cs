using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
         
        public IActionResult Index()
        {
            var values = blogManager.GetBlogsListWithCategory();
            return View(values);
        }


    }
}
