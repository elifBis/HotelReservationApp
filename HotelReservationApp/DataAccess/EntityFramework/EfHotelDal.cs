using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.DataAccess.Abstract;
using HotelReservationApp.DataAccess.Repository;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.DataAccess.EntityFramework
{
    public class EfHotelDal : GenericRepository<Hotel>, IHotelDal
    {
        public EfHotelDal(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
