using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
          var findWriter =  writers.FirstOrDefault(x => x.Id == writerid);
          var JsonWriters = JsonConvert.SerializeObject(findWriter);
          return Json(JsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
           var JsonWriters = JsonConvert.SerializeObject(w);
            return Json(JsonWriters);
        }

      
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(writer);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Samet"
            },
            new WriterClass
            {
                Id = 2,
                Name = "Şevval"
            },
            new WriterClass
            {
                Id = 3,
                Name = "Nurana"
            },
            new WriterClass
            {
                Id = 4,
                Name = "Mete Serkan"
            }

        };

    }
}
