﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectEntityLayer.Concrete;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]//Api de mutlaka attribute kullanarak işaretleme yaparız
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateList(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);

            return Ok(values);
        }
    }
}
