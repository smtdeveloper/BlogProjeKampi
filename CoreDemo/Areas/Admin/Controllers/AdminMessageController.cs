using BusinessLayer.Concrete;
using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public AdminMessageController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            //ViewBag.InboxCount = c.Messages2.Where(x => x.ReceiverID == writerID).Select(y => y.MessageStatus == false).Count();


            return View(values);
        }

        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerID);

            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(SendMessageModelView model)
        {
            Message2 message = new Message2();
            var reciever =  _userManager.FindByEmailAsync(model.Email);

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            message.SenderID = writerID;
            message.ReceiverID = reciever.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = false;
            message.Subject = model.Subject;
            message.MessageDetails = model.Detail;
            message.IsDelete = false;
            mm.TAdd(message);



            return RedirectToAction("Sendbox", "AdminMessage");
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var inboxMessageCount = mm.GetInboxListByWriter(user.Id).Count();
            var sendMessageCount = mm.GetSendboxListByWriter(user.Id).Count();
            ViewBag.imc = inboxMessageCount;
            ViewBag.smc = sendMessageCount;

            var value = mm.TGetById(id);
            if (value.MessageStatus == false)
            {
                value.MessageStatus = true;
                mm.TUpdate(value);
            }

            return View(value);
        }


    }
}
