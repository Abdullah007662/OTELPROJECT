using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectDataAccessLayer.Concrete;
using OtelWebApi.Models;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Context context = new Context();
            //var values = _appUserService.TUserListWithWorkLocations();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new
            AppUserWithWorkLocationViewModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationID = y.WorkLocationID,
                WorkLocationName = y.WorkLocation!.WorkLocationName,
                City=y.City,
                Country=y.Country,
                Gender=y.Gender,
                UserImage=y.UserImage
            }).ToList();
            return Ok(values);
        }
    }
}
