using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Models.Staff;
using System.Text;

namespace OteLProjectWebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri ÇEvir demek
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> AddStaff(AddStaffViewModel addStaffViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addStaffViewModel);//Yukarıda Deserilize Etmiştik Çünkü json türünde bir data bize geliyordu o datayı listelemek istiyorduk 
            //Şuan Yaptığımız SErialize etmek ise Biz Bir Data gönderecegiz Bu data json a Dönüşecek.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5132/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5132/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var responseMessage = await client.GetAsync($"http://localhost:5132/api/Staff/{id}"); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel updateStaffViewModel)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var jsonData = JsonConvert.SerializeObject(updateStaffViewModel);//Modelden Gelen Degeri Serilize Etmiş Olduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5132/api/Staff/",stringContent); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
