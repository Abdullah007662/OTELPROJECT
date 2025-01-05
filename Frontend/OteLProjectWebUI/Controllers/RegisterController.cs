using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Dtos.RegisterDTO;

namespace OteLProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(CreateNewUserDTO createNewUserDTO)
        
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                //Bu Alanda Atamalarımızı Gerçekleştirecegiz
                Name=createNewUserDTO.Ad,
                Surname=createNewUserDTO.SoyAd,
                Email=createNewUserDTO.Mail,
                UserName=createNewUserDTO.UserName,
                City=createNewUserDTO.Şehir,
                WorkLocationID=1
                
            };
            var result = await _userManager.CreateAsync(appUser,createNewUserDTO.Password!);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
