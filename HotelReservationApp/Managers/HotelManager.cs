
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.DataAccess.Abstract;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Managers
{
    public class HotelService
    {
        private readonly MyDbContext _dbContext;

        public HotelService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Hotel> GetAllHotels()
        {
            return _dbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _dbContext.Hotels
                .Include(h => h.City)
                .FirstOrDefault(h => h.Id == id);
        }

        public List<RoomType> GetRoomTypesByHotelId(int hotelId)
        {
            return _dbContext.RoomTypes
                .Where(rt => rt.HotelId == hotelId)
                .ToList();
        }
        //public Hotel GetHotelDetailsByCity(int hotelId, int cityId)
        //{
        //    return _dbContext.Hotels
        //        .Include(h => h.City)
        //        .FirstOrDefault(h => h.Id == hotelId && h.CityId == cityId);
        //}

    }
}