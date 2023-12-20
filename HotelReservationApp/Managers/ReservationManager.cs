
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using HotelReservationApp.Managers;
using HotelReservationApp.Services;

namespace HotelReservationApp.Managers
{
    public class ReservationService : IReservationService
    {
        private readonly MyDbContext _dbContext;
        private readonly IRoomTypeService _roomTypeService;

        //public ReservationService(MyDbContext dbContext, IRoomTypeService roomTypeService)
        //{
        //    _dbContext = dbContext;
        //    _roomTypeService = roomTypeService;
        //}
        public ReservationService(MyDbContext dbContext, IRoomTypeService roomTypeService)
        {
            _dbContext = dbContext;
            _roomTypeService = roomTypeService;

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

        //public int CalculateTotalPrice(int roomTypeId, DateTime checkInDate, DateTime checkOutDate, int pricePerNight)
        //{
        //    RoomType roomType = _roomTypeService.GetRoomTypeById(roomTypeId);

        //    if (roomType != null)
        //    {
        //        int nights = (int)(checkOutDate - checkInDate).TotalDays;
        //        int totalPrice = nights * roomType.PricePerNight;

        //        return totalPrice;
        //    }

        //    return 0;
        //}
    }
}

