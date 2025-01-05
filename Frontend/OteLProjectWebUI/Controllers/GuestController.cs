using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.GuestDTO;
using OteLProjectWebUI.Models.Staff;
using System.Text;

namespace OteLProjectWebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/Guest");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultGuestDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri ÇEvir demek
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDTO createGuestDTO)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createGuestDTO);//Yukarıda Deserilize Etmiştik Çünkü json türünde bir data bize geliyordu o datayı listelemek istiyorduk 
                                                                           //Şuan Yaptığımız SErialize etmek ise Biz Bir Data gönderecegiz Bu data json a Dönüşecek.
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5132/api/Guest", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();

        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5132/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var responseMessage = await client.GetAsync($"http://localhost:5132/api/Guest/{id}"); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDTO updateGuestDTO)
        {
            if (ModelState.IsValid)
            {

                var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
                var jsonData = JsonConvert.SerializeObject(updateGuestDTO);//Modelden Gelen Degeri Serilize Etmiş Olduk
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5132/api/Guest/", stringContent); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }
    }
}
