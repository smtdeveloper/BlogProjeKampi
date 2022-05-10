using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            string api = "59ae7e420ee51ebffa30a7642e93774b";
            string city = "kutahya";
            string connection =
                "https://api.openweathermap.org/data/2.5/weather?q=kütahya&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.HavaDurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
