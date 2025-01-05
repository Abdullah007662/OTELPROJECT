using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectEntityLayer.Concrete;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService BookingService)
        {
            _bookingService = BookingService;
        }

        [HttpGet]//Api de mutlaka attribute kullanarak işaretleme yaparız
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);

            return Ok(values);
        }
        [HttpPut("aaa")]
        public IActionResult aaa(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();    
        }
        [HttpPut("bbbb")]
        public IActionResult bbbb(int id)
        {
            _bookingService.TBookingStatusChangeApproved2(id);
            return Ok();
        }
        [HttpGet("Last5Booking")]
        public IActionResult Last5Booking()
        {
            var value = _bookingService.TLast5Bookings();
            return Ok(value);
        }
        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok();
        }
        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
            _bookingService.TBookingStatusCancel(id);
            return Ok();
        }
        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusWait(id);
            return Ok();
        }
    }
}
