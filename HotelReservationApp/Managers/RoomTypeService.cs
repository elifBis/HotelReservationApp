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

        public Hotel GetHotelByRoomId(int roomId)
        {
            return _dbContext.Hotels.Find(roomId);

        }

        public RoomType GetRoomTypeById(int roomTypeId)
        {
            return _dbContext.RoomTypes.Find(roomTypeId);
        }

        public void TAdd(RoomType entity)
        {
            _dbContext.RoomTypes.Add(entity);
            _dbContext.SaveChanges();
        }

        public void TDelete(RoomType t)
        {
            var room = _dbContext.RoomTypes.Find(t);
            if (room != null)
            {
                _dbContext.RoomTypes.Remove(room);
                _dbContext.SaveChanges();
            }
        }

        public void TUpdate(RoomType t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public RoomType TGetByID(int id)
        {
            return _dbContext.RoomTypes.Find(id);
        }

        public List<RoomType> TGetList()
        {
            return _dbContext.RoomTypes.ToList();
        }


    }


}

