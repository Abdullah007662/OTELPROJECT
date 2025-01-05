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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        // EfBooking Hata vermesinin Sebebi Sen diger tarafta GenericRepositoryden miras aldın. Öbür tarafta Contextli Constracter üzewrinde geçmişti sende burada constracter çagırmak zorundasın.Burada Constracterde Context i Geçmen gerekiyor.
        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values!.Status = "Onaylandı";
            context.SaveChanges();//Değişiklikleri Kaydet .
        }

        public void BookingStatusCancel(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values!.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values!.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values!.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusWait(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value!.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            var value = context.Bookings.Count();
            return value;
        }


        public List<Booking> Last5Bookings()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(5).ToList();
            return values;
        }
    }
}
