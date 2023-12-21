using System.Collections.Generic;
using System.Linq;
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Services
{
    public class CityService:IGenericService<City>
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

        public void TAdd(City t)
        {
            _dbContext.Cities.Add(t);
            _dbContext.SaveChanges();
        }

        public void TDelete(City t)
        {
            throw new NotImplementedException();
        }

        public City TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(City t)
        {
            throw new NotImplementedException();
        }
    }

}