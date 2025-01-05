using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=man"),
                Headers =
                {
                    { "x-rapidapi-key", "bdb281f20cmsh02da8f762c0c431p1fd095jsnf0cac93896cc" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            // ol degerler gelmiyor bak göstercem UI kısmında 
            // çalıştırsana bi

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON'u modele dönüştür
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);

                // Eğer results boşsa boş bir View dön
                if (values?.results == null || !values.results.Any())
                {
                    return View(new List<Result>());
                }

                // Results'u View'a gönder
                return View(values.results);
            }
        }
    }
}
