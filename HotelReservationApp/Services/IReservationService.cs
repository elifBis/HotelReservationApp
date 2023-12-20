
using HotelReservationApp.Models;
using System.Collections.Generic;

namespace HotelReservationApp.Services
{
    public interface IReservationService
    {
        bool MakeReservation(string userId, ReservationModel reservationModel);
        //int CalculateTotalPrice(int roomTypeId, DateTime checkInDate, DateTime checkOutDate, int pricePerNight);
    }
}