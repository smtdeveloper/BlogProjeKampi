using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public List<Notification> TGetAll()
        {
           return _notificationDal.GetAll();
        }

        public List<Notification> TGetAll3Last()
        {
            return _notificationDal.GetAll().Take(3).ToList();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
