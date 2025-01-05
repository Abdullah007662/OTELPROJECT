using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.RoomDTO;
using OteLProjectWebUI.Models.Staff;
using System.Text;

namespace OteLProjectWebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultRoomDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bİr nesneye Geri ÇEvir demek
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDTO createRoomDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRoomDTO);//Yukarıda Deserilize Etmiştik Çünkü json türünde bir data bize geliyordu o datayı listelemek istiyorduk 
            //Şuan Yaptığımız SErialize etmek ise Biz Bir Data gönderecegiz Bu data json a Dönüşecek.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5132/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5132/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var responseMessage = await client.GetAsync($"http://localhost:5132/api/Room/{id}"); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDTO updateRoomDTO)
        {
            var client = _httpClientFactory.CreateClient();//İstemci Oluşturduk
            var jsonData = JsonConvert.SerializeObject(updateRoomDTO);//Modelden Gelen Degeri Serilize Etmiş Olduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5132/api/Room/", stringContent); // GetAsync Yapmamızın sebebi Güncelleyecegimiz verileri getirmek istiyoruz ondan dolayı
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
