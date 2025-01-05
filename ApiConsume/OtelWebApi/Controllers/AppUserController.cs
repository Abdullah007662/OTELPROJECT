using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OteLProjectBusinessLayer.Abstract;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]//Api de mutlaka attribute kullanarak işaretleme yaparız
        public IActionResult UserListWithWorkLocation()
        {
            var values = _appUserService.TUserListWithWorkLocation();
            return Ok(values);
        }
        [HttpGet("AppUserList")]
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
    }
}
