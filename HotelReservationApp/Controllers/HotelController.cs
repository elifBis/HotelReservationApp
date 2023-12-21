
using HotelReservationApp.Managers;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservationApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult Index(int cityId)
        {
            var hotels = _hotelService.GetAllHotels();
            return View(hotels);
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


        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHotel(Hotel hotel)
        {

                _hotelService.TAdd(hotel);
                return RedirectToAction("Index");
           
        }

        public IActionResult Edit(int id)
        {
            Hotel hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelService.TUpdate(hotel);
                return RedirectToAction("Index", "Hotel");
            }

            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            Hotel hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

    }



}

