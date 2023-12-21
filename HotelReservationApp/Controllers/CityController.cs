using HotelReservationApp.Managers;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class CityController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ICityService _cityService;
        
        public CityController(IHotelService hotelService, ICityService cityService)
        {
            _cityService = cityService;
            _hotelService = hotelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(City city)
        {
            _cityService.TAdd(city);
            return RedirectToAction("Index");
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
