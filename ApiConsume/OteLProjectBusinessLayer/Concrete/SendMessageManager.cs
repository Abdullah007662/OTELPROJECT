using OteLProjectBusinessLayer.Abstract;
using OteLProjectDataAccessLayer.Abstract;
using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Concrete
{
    public class SendMessageManager : ISendMesaggeService
    {
        private readonly ISendeMessageDal _sendeMessageDal;

        public SendMessageManager(ISendeMessageDal sendeMessageDal)
        {
            _sendeMessageDal = sendeMessageDal;
        }

        public void TDelete(SendMessage t)
        {
            _sendeMessageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            return _sendeMessageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendeMessageDal.GetList();
        }

        public int TGetSendMessageCount()
        {
            return _sendeMessageDal.GetSendMessageCount();
        }

        public void TInsert(SendMessage t)
        {
            _sendeMessageDal.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendeMessageDal.Update(t);
        }
    }
}
