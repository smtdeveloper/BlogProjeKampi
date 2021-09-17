using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface ICategoryDal
    {
        List<Category> ListAll();
        Category GetById(int Id);
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
       


    }
}
