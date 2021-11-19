using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
           
            ViewBag.ToplamBlogSayisi = blogManager.TGetAll().Count();
            ViewBag.YazarinBlogSayisi = blogManager.GetBlogsListWithWriter(20).Count();
            ViewBag.KategoriSayisi = categoryManager.TGetAll().Count();
            return View();
        }


    }
}
