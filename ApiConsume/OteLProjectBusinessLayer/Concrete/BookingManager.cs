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
    public class BookingManager:IBookingService
    {
        private readonly IBookingDal _booking;

        public BookingManager(IBookingDal booking)
        {
            _booking = booking;
        }

        public void TBookingStatusApproved(int id)
        {
            _booking.BookingStatusApproved(id);
        }

        public void TBookingStatusCancel(int id)
        {
            _booking.BookingStatusCancel(id);
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
            _booking.BookingStatusChangeApproved(booking);
        }

        public void TBookingStatusChangeApproved2(int id)
        {
            _booking.BookingStatusChangeApproved2(id);
        }

        public void TBookingStatusWait(int id)
        {
            _booking.BookingStatusWait(id);
        }

        public void TDelete(Booking t)
        {
            _booking.Delete(t);
        }

        public int TGetBookingCount()
        {
            return _booking.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
            return _booking.GetByID(id);
        }

        public List<Booking> TGetList()
        {
            return _booking.GetList();
        }

        public void TInsert(Booking t)
        {
            _booking.Insert(t);
        }

        public List<Booking> TLast5Bookings()
        {
            return _booking.Last5Bookings();
        }

        public void TUpdate(Booking t)
        {
            _booking.Update(t);
        }
    }
}
