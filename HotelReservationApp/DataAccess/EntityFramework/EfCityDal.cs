using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.DataAccess.Abstract;
using HotelReservationApp.DataAccess.Repository;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.DataAccess.EntityFramework
{
    public class EfCityDal : GenericRepository<City>, ICityDal
    {
        public EfCityDal(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
