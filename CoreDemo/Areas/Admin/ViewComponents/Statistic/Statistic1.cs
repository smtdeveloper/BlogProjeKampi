using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context(); 
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = bm.TGetAll().Count();
            ViewBag.MessageCount = c.Contacts.Count();
            ViewBag.CommentCount = c.Comments.Count();
           
            return View();
        }
    }
}
