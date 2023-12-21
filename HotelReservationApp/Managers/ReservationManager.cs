
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using HotelReservationApp.Managers;
using HotelReservationApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Managers
{
    public class ReservationService : IReservationService
    {
        private readonly MyDbContext _dbContext;
        private readonly IRoomTypeService _roomTypeService;

        public ReservationService(MyDbContext dbContext, IRoomTypeService roomTypeService)
        {
            _dbContext = dbContext;
            _roomTypeService = roomTypeService;

        }

        public List<UserReservationViewModel> GetUserReservations(string userId)
        {
            var userReservations = _dbContext.Reservations
                .Where(r => r.UserId == userId)
                .Select(r => new UserReservationViewModel
                {
                    ReservationId = r.Id,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    RoomTypeId = r.RoomTypeId,
                    HotelName = _dbContext.RoomTypes
                                    .Where(rt => rt.Id == r.RoomTypeId)
                                    .Select(rt => rt.Hotel.Name)
                                    .FirstOrDefault(),
                    TotalPrice = r.TotalPrice
                })
                .ToList();

            return userReservations;
        }

        public int CalculateTotalPrice(DateTime checkInDate, DateTime checkOutDate, int id)
        {
            var totalDays = (int)(checkOutDate - checkInDate).TotalDays;
            return totalDays * _roomTypeService.GetRoomTypeById(id).PricePerNight;
        }

        public bool MakeReservation(string userId, ReservationModel reservationModel)
        {
            var roomType = _dbContext.RoomTypes.FirstOrDefault(rt => rt.Id == reservationModel.RoomTypeId);

            if (roomType == null)
            {
                return false;
            }

            var reservation = new Reservation
            {
                UserId = userId,
                RoomTypeId = reservationModel.RoomTypeId,
                CheckInDate = reservationModel.CheckInDate,
                CheckOutDate = reservationModel.CheckOutDate,
                TotalPrice = CalculateTotalPrice(reservationModel.CheckInDate, reservationModel.CheckOutDate, _roomTypeService.GetRoomTypeById(reservationModel.RoomTypeId).Id)
            };

            try
            {
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Kullanıcı için rezervasyon silme
        public bool CancelReservation(string userId, int reservationId)
        {
            try
            {
                var reservation = _dbContext.Reservations
                    .Where(r => r.Id == reservationId && r.UserId == userId)
                    .FirstOrDefault();

                if (reservation != null)
                {
                    _dbContext.Reservations.Remove(reservation);
                    _dbContext.SaveChanges();
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        //Admşn işlemleri
        public void Delete(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
            }
        }

        public List<Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        public Reservation GetById(int id)
        {
            return _dbContext.Reservations.Find(id);
        }

        public void Update(Reservation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

