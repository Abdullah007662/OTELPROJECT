using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Models.Setting;

namespace OteLProjectWebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = user!.Name;
            userEditViewModel.Surname = user!.Surname;
            userEditViewModel.Email = user!.Email;
            userEditViewModel.UserName = user!.UserName;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if (userEditViewModel.Password == userEditViewModel.ConfrimPassword)
            {


                var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
                user!.Name = userEditViewModel.Name;
                user.Surname = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password!);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
    }
}
