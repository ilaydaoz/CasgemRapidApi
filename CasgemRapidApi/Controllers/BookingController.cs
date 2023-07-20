using Microsoft.AspNetCore.Mvc;

namespace CasgemRapidApi.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
