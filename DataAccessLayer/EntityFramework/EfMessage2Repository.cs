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
    //Yarım kalan sigaram...
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.SenderUser).Where(x => x.ReceiverID == id && x.IsDelete == false).ToList();
            }
        }

        public List<Message2> GetSendboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.ReceiverUser).Where(x => x.SenderID == id && x.IsDelete == false).ToList();
            }
        }
        public Message2 GetMessageById(int id)
        {
            using (Context c = new Context())
            {
                return c.Messages2.Include(x => x.SenderUser).Include(x => x.ReceiverUser).Where(x => x.MessageID == id).FirstOrDefault();
            }
        }
    }
}
