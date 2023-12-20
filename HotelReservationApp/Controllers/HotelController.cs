using HotelReservationApp.Managers;
using HotelReservationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservationApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelService _hotelService;

        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public IActionResult Index(int cityId)
        {
            // Seçilen şehirdeki otelleri listeleyen eylem
            // Burada otelleri hotel modelinden alabilirsiniz
            return View();
        }

        public IActionResult Details(int id)
        {
            var hotel = _hotelService.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }
            var roomTypes = _hotelService.GetRoomTypesByHotelId(id);


            var hotelDetailsViewModel = new HotelDetailsViewModel
            {
                Hotel = hotel,
                RoomTypes = roomTypes
            };

            return View(hotelDetailsViewModel);
        }
    }
}
