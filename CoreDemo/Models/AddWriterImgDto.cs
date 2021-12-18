using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class AddWriterImgDto
    {
       
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public IFormFile Image { get; set; } // dosyadan veri secebilmek için 
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
