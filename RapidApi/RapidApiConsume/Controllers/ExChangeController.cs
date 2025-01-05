using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class ExChangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "bdb281f20cmsh02da8f762c0c431p1fd095jsnf0cac93896cc" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Rootobject'e deserialize ediliyor
                var values = JsonConvert.DeserializeObject<Rootobject>(body);

                if (values?.data?.exchange_rates != null)
                {
                    // Exchange rates listesini View'a gönder
                    return View(values.data.exchange_rates.ToList());
                }

                // Eğer exchange_rates null ise boş bir sayfa döner
                return View(new List<Exchange_Rates>());
            }
        }
    }
}
