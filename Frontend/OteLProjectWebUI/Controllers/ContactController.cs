using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.BookingDTO;
using OteLProjectWebUI.Dtos.ContactDTO;
using OteLProjectWebUI.Dtos.MessageCategoryDTO;
using OteLProjectWebUI.Dtos.RoomDTO;
using System.Net.Http;
using System.Text;

namespace OteLProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/MessageCategory");


            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultMessageCategoryDTO>>(jsonData);//gelen Veriyi Deserialize et Yani Dinamik Bir nesneye Geri ÇEvir demek
            List<SelectListItem> category = (from x in value
                                             select new SelectListItem
                                             {
                                                 Text = x.MessageCategoryName,
                                                 Value = x.MessageCategoryID.ToString()

                                             }).ToList();

            ViewBag.v = category;
            return View();

        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDTO createContactDTO)
        {
            createContactDTO.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDTO);
            if (createContactDTO == null)
            {
                throw new ArgumentNullException(nameof(createContactDTO), "Gönderilen model null. Lütfen form verilerini kontrol edin.");
            }
            //Yukarıda Deserilize Etmiştik Çünkü json türünde bir data bize geliyordu o datayı listelemek istiyorduk 
             //Şuan Yaptığımız Serialize etmek ise Biz Bir Data gönderecegiz Bu data json a Dönüşecek.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5132/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();

        }
    }
}
