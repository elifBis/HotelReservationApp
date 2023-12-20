using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
