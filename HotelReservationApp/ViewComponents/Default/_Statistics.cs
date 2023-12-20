using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationApp.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            //// using var c = new MyDbContext();
            // ViewBag.v1 = c.Hotels.Count();
            // ViewBag.v2 = c.AppUser.Count();
            // ViewBag.v3 = c.Reservations.Count();
            // //ViewBag.v4 = c.PopulerOtellerT.Count();
            return View();

        }
    }
}
