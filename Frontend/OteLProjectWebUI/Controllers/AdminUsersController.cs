using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Dtos.AppUserDTO;
using OteLProjectWebUI.Dtos.RoomDTO;

namespace OteLProjectWebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        #region deneme
        //private readonly UserManager<AppUser> _userManager;

        //public AdminUsersController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var values = _userManager.Users.ToList();
        //    return View(values);
        //}
        #endregion
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri Çevir demek
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> AppUserList()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/AppUser/AppUserList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri ÇEvir demek
                return View(value);
            }
            return View();
        }
    }
}
