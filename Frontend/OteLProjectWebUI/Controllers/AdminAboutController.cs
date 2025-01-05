using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.AboutDTO;
using OteLProjectWebUI.Dtos.BookingDTO;
using OteLProjectWebUI.Models.Staff;
using System.Text;

namespace OteLProjectWebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri ÇEvir demek
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var responseMessage = await client.GetAsync($"http://localhost:5132/api/About/{id}"); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var jsonData = JsonConvert.SerializeObject(updateAboutDTO);//Modelden Gelen Degeri Serilize Etmiş Olduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5132/api/About/", stringContent); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
