using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Abstract
{
    public interface ISendMesaggeService : IGenericService<SendMessage>
    {
        public int TGetSendMessageCount();
    }
}
