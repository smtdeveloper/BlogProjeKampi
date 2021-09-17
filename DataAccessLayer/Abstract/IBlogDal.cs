using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
  public  interface IBlogDal
    {
        List<Blog> ListAll();
        Blog GetById(int Id);
        void Add(Blog blog );
        void Delete(Blog blog);
        void Update(Blog blog);
    }
}
