using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Views.Shared.Components.WriterMessageNotification
{
    public class WriterNotifications : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.TGetAll3Last();
            return View(values);
        }
    }
}
