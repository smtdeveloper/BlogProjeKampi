using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
       
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.ToplamBlogSayisi = blogManager.TGetAll().Count();
            ViewBag.YazarinBlogSayisi = c.Blogs.Where(x => x.WriterId == writerid).Count();
            ViewBag.KategoriSayisi = categoryManager.TGetAll().Count();
            return View();
        }


    }
}
