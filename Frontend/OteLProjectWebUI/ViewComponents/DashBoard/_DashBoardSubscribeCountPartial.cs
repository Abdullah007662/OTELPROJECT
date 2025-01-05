using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OteLProjectWebUI.Dtos.FollowersDTO;


namespace OteLProjectWebUI.ViewComponents.DashBoard
{
    public class _DashBoardSubscribeCountPartial : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
           /* List<ResultİnstagramFollowersDTO> resultİnstagramFollowersDTOs = new List<ResultİnstagramFollowersDTO>();*///Liste Olarak Çektigimiz İçin hata veriyor sadece 2 deger çekecegiz ondan dolayı buna gerek yok
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/abdullah.kocdemir"),
                Headers =
    {
        { "x-rapidapi-key", "bdb281f20cmsh02da8f762c0c431p1fd095jsnf0cac93896cc" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultİnstagramFollowersDTO resultİnstagramFollowersDTOs =JsonConvert.DeserializeObject<ResultİnstagramFollowersDTO>(body)!;
                return View(resultİnstagramFollowersDTOs);
            }
        }
    }
}
