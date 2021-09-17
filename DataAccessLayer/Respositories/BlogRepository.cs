using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respositories
{
    public class BlogRepository : IBlogDal
    {
        public void Add(Blog blog)
        {
            using var c = new Context();
            c.Add(blog);
            c.SaveChanges();
        }

        public void Delete(Blog blog)
        {
            using var c = new Context();
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog GetById(int Id)
        {
            using var c = new Context();
            return  c.Blogs.Find(Id);
        }

        public List<Blog> ListAll()
        {
            using var c = new Context();
           return c.Blogs.ToList();
        }

        public void Update(Blog blog)
        {
            using var c = new Context();
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
