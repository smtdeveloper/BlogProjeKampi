using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDahsboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            return View(values);
        }


    }
}
