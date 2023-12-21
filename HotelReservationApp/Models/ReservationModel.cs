using System.ComponentModel.DataAnnotations;

namespace HotelReservationApp.Models
{
    public class ReservationModel
    {
        public int RoomTypeId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int TotalPrice { get; set; }

        public int DailyPrice { get; set; }

    }
}
