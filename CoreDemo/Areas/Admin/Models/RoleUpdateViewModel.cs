using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int IsDelete { get; set; }
    }
}
