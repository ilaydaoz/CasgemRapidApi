using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname = "London")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "89fcbeb61amsh1fdb44656d3eb7ap1a545djsnfc5ef26ed6f0" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CityLocationViewModel>>(body);
                return View(values.Take(1).ToList());
            }
           
        }
    }
}