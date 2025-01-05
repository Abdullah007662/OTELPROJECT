using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectDataAccessLayer.EntityFrameWork;
using OteLProjectEntityLayer.Concrete;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMesaggeService _sendMesaggeService;

        public SendMessageController(ISendMesaggeService sendMesaggeService)
        {
            _sendMesaggeService = sendMesaggeService;
        }

        [HttpGet]//Api de mutlaka attribute kullanarak işaretleme yaparız
        public IActionResult SendMessageList()
        {
            var values = _sendMesaggeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMesaggeService.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMesaggeService.TGetByID(id);
            _sendMesaggeService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSendMessageList(SendMessage sendMessage)
        {
            _sendMesaggeService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _sendMesaggeService.TGetByID(id);

            return Ok(values);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMesaggeService.TGetSendMessageCount());
        }
    }
}
