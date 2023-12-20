using System.Collections.Generic;
using System.Linq;
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Services
{
    public class CityService
    {
        private readonly MyDbContext _dbContext;

        public CityService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetCities()
        {
            return _dbContext.Cities.ToList();
        }
        public List<Hotel> GetHotelsInCity(int cityId)
        {
            return _dbContext.Hotels
                .Where(h => h.CityId == cityId)
                .ToList();
        }
    }

}