using OteLProjectDataAccessLayer.Abstract;
using OteLProjectDataAccessLayer.Concrete;
using OteLProjectDataAccessLayer.Repositories;
using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.EntityFrameWork
{
    public class EfSendMessage : GenericRepository<SendMessage>, ISendeMessageDal
    {
        public EfSendMessage(Context context) : base(context)
        {
        }

        public int GetSendMessageCount()
        {
            var context=new Context ();
            return context.SendMessages.Count();
        }
    }
}
