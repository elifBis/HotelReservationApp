using HotelReservationApp.Managers;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HotelReservationApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly CityService _cityService;
        public HomeController(CityService cityService)
        {
            _cityService = cityService;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            var cities = _cityService.GetCities();
            var viewModel = new CityViewModel { Cities = cities };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ListHotels(CityViewModel viewModel)
        {
            if (viewModel.SelectedCityId == 0)
            {
                return RedirectToAction("Index");
            }

            var hotels = _cityService.GetHotelsInCity(viewModel.SelectedCityId);

            return View("HotelList", hotels);
        }

    }
}