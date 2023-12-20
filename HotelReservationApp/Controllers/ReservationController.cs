
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace HotelReservationApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomTypeService _roomTypeService;

        public ReservationController(IReservationService reservationService, IRoomTypeService roomTypeService)
        {
            _reservationService = reservationService;
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public IActionResult MakeReservation(int roomTypeId)
        {
            //var roomType = _roomTypeService.GetRoomTypeById(roomTypeId);

            //if (roomType == null)
            //{
            //    return NotFound();
            //}
            int dailyPrice = _roomTypeService.GetRoomTypeById(roomTypeId).PricePerNight;

            var model = new ReservationModel
            {
                RoomTypeId = roomTypeId,
                DailyPrice = dailyPrice
                //CheckInDate = DateTime.Now.Date,
                //CheckOutDate = DateTime.Now.Date.AddDays(1)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult MakeReservation(ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var success = _reservationService.MakeReservation(userId, reservationModel);

                if (success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Reservation could not be made.");
                }
            }

            return View(reservationModel);
        }


    }
}