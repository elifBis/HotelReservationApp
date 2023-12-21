using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddRoomType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoomType(RoomType roomType)
        {

            _roomTypeService.TAdd(roomType);
            return RedirectToAction("Index");

        }
    }
}
