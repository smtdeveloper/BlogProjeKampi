using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {

            int id = 20;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

    }
}
