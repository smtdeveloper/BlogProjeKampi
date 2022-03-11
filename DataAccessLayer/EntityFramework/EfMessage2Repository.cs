using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
