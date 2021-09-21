using DataAccessLayer.Abstract;
using DataAccessLayer.Respositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfAboutRepository : GenericRepository<About> , IAboutDal
    {

    }
}
