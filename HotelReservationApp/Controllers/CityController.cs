using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class CityController : Controller
    {
        private readonly IHotelService _hotelService;

        public IActionResult Index()
        {
            return View();
        }
        public CityController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        //public IActionResult ListHotels(int cityId)
        //{
        //    var hotelsInCity = _hotelService.GetHotelsInCity(cityId);

        //    // Eğer şehirde otel bulunamazsa, bir hata sayfasına yönlendirilebilir.
        //    if (hotelsInCity == null || hotelsInCity.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    // Şehre göre otelleri listeleyen bir view'e yönlendir
        //    return View(hotelsInCity);
        //}
    }
}
