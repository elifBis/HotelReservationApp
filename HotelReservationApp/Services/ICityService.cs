using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Services
{
    public interface ICityService:IGenericService<City>
    {
    }
}
