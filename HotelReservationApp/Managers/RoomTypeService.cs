using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelReservationApp.Managers
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly MyDbContext _dbContext;

        public RoomTypeService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _dbContext.RoomTypes.ToList();
        }

        public RoomType GetRoomTypeById(int roomTypeId)
        {
            return _dbContext.RoomTypes.Find(roomTypeId);
        }
    }


}

