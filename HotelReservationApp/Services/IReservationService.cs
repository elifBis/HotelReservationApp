using HotelReservationApp.Models;
using System.Collections.Generic;

namespace HotelReservationApp.Services
{
    public interface IReservationService
    {
        List<UserReservationViewModel> GetUserReservations(string userId);
        bool MakeReservation(string userId, ReservationModel reservationModel);
        public bool CancelReservation(string userId, int reservationId);
    }
}