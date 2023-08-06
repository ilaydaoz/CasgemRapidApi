﻿using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string adult="1", string checkinDate="2023-9-7", string cityID= "-553173", string checkoutDate="2023-09-28", string roomNumber="1", string child="1")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkinDate}&filter_by_currency=USD&dest_id={cityID}&locale=en-gb&checkout_date={checkoutDate}&units=metric&room_number={roomNumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                Headers =
    {
        { "X-RapidAPI-Key", "f2aca2c6b5msh6e1ed4b2f16a931p170f45jsndf22767a5549" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<HotelListModel>(body);
                return View(value.results.ToList());
            }
        }
    }
}
