using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
			//List<ImdbMovieListViewModel> model = new List<ImdbMovieListViewModel>();

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "d1f43f90aamsh85263efd5fc8d16p1624b4jsnc27aa8d24638" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var model =JsonConvert.DeserializeObject<List<ImdbMovieListViewModel>>(body);
				return View(model.ToList());
			}
		
        }
    }
}
