using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.Abstract
{
    //Her Bir Entity İçin Bir İnterface Tanımlayacagız.Sebebi ise Entityleri Generic İfade ile haberdar etmemiz gerekiyor 
    public interface IRoomDal:IGenericDal<Room>
    {
        int RoomCount();
    }
}
