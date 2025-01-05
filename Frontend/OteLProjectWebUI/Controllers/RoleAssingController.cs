using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Dtos.AppUserDTO;

namespace OteLProjectWebUI.Controllers
{
    public class RoleAssingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssingController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var value = _userManager.Users.ToList();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);// İlk Başta Burada Id Yakalıyoruz.
            //TempData http post tarafından httpget e veri taşımak için kullanacagız.
            TempData["userid"] = user!.Id;
            var roles = _roleManager.Roles.ToList();//Burada Rollerin listesini getiriyoruz.
            var userRoles = await _userManager.GetRolesAsync(user);//Kullanıcının rollerini getiriyoruz.
            List<RoleAssingViewModel> roleAssingViewModels = new List<RoleAssingViewModel>();
            foreach(var item in roles)
            {
                RoleAssingViewModel model = new RoleAssingViewModel();
                model.RoleID = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name!);
                roleAssingViewModels.Add(model);

            }; // roles üzerinden bütün degerleri okutacagız.

            return View(roleAssingViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssingRole(List<RoleAssingViewModel> roleAssing)
        {
            var userid = (int)TempData["userid"]!;
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach(var item in roleAssing)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user!, item.RoleName!);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user!, item.RoleName!);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
