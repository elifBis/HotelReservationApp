
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Managers
{
    public class HotelService:IHotelService
    {
        private readonly MyDbContext _dbContext;

        public HotelService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<HotelViewModel> GetAllHotels()
        {
            var userReservations = _dbContext.Hotels.Select(
                h => new HotelViewModel{
                     Name = h.Name,
                     Description = h.Description,
                     ImageUrl = h.ImageUrl,
                     City = _dbContext.Cities
                     .Where(ct => ct.Id == h.CityId)
                     .Select(ct => ct.Name)
                     .FirstOrDefault(),
                              }).ToList();

            return userReservations;
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

        public void TAdd(Hotel entity)
        {
            _dbContext.Hotels.Add(entity);
            _dbContext.SaveChanges();
        }

        public void TDelete(Hotel t)
        {
            var hotel = _dbContext.Hotels.Find(t);
            if (hotel != null)
            {
                _dbContext.Hotels.Remove(hotel);
                _dbContext.SaveChanges();
            }
        }

        public void TUpdate(Hotel t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Hotel TGetByID(int id)
        {
            return _dbContext.Hotels.Find(id);
        }

        public List<Hotel> TGetList()
        {
            return _dbContext.Hotels.ToList();
        }
    }
}