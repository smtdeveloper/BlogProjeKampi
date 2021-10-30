using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Views.Shared.Components.WriterMessageNotification
{
    public class WriterNotifications : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
