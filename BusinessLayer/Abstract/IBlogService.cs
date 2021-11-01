using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetLast3Blog();
        List<Blog> GetBlogByID(int id);
        List<Blog> GetBlogsListWithCategory();
        List<Blog> GetBlogsListWithWriter(int id);
    }
}
