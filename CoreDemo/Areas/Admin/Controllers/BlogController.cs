using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID"; 
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var context = stream.ToArray();
                    return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dosya.xlsx");
                }

            }
            

              
        }

        public IActionResult ExportDinamikExcelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRowCount = 2;

                foreach (var item in GetDinamikBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var context = stream.ToArray();
                    return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dosya.xlsx");
                }

            }



        }

        public IActionResult BlogListExcel()
        {
            return View();
        }
        public List<BlogModel> GetBlogList()
        {

            var bm = new List<BlogModel>
            {
                new BlogModel{ID = 1 , BlogName= "Samet Akca"},
                new BlogModel{ID = 2 , BlogName= "Eslem Betül"},
                new BlogModel{ID = 3 , BlogName= "test"}
            };
            return bm;

        }

        public List<BlogModel> GetDinamikBlogList()
        {
            var bm = new List<BlogModel>();

            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID = x.BlogId,
                    BlogName = x.Title
                }).ToList();
            }

            return bm;
        }

        public IActionResult DinamikBlogList()
        {
            return View();
        }
    }
}
