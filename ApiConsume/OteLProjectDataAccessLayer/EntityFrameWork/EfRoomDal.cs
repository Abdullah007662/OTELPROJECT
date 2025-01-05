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
    public class EfRoomDal:GenericRepository<Room>,IRoomDal
    {
        // EfRoomDal Hata vermesinin Sebebi Sen diger tarafta GenericRepositoryden miras aldın. Öbür tarafta Contextli Constracter üzewrinde geçmişti sende burada constracter çagırmak zorundasın.Burada Constracterde Context i Geçmen gerekiyor.
        public EfRoomDal (Context context):base(context)
        {
                
        }

        public int RoomCount()
        {
            var context = new Context();
            var value = context.Rooms.Count();
            return value;
        }
    }
}
