using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.GuestDTO;
using System.Net.Http;

namespace OteLProjectWebUI.ViewComponents.DashBoard
{
    public class _DashBoardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashBoardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage = await client.GetAsync("http://localhost:5132/api/DashBoardWidget/StaffCount");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.StaffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();//Bir Tane İstemci Oluştur
            var responseMessage2 = await client2.GetAsync("http://localhost:5132/api/DashBoardWidget/BookingCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.BookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5132/api/DashBoardWidget/AppUserCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.AppUserCount = jsonData3;


            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:5132/api/DashBoardWidget/RoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.RoomCount = jsonData4;


            return View();
        }
    }
}
