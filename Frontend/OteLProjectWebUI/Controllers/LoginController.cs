using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Dtos.LoginDTO;

namespace OteLProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Kullanıcı_Adı!, loginUserDTO.Şifre!, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminPaneli");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
