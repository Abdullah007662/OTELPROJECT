using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(Booking booking);
        void TBookingStatusChangeApproved2(int id);
        int TGetBookingCount();
        List<Booking> TLast5Bookings();

        void TBookingStatusApproved(int id);

        void TBookingStatusCancel(int id);
        void TBookingStatusWait(int id);



    }
}
