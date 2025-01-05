using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectEntityLayer.Concrete;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]//Api de mutlaka attribute kullanarak işaretleme yaparız
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            _staffService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateList(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            
            return Ok(values);
        }
        [HttpGet("Last4Staff")]
        public IActionResult Last4Staff()
        {
            var value = _staffService.TList4Staffs();
            return Ok(value);
        }
    }
}
