using System.ComponentModel.DataAnnotations;

namespace HotelReservationApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        public string UserId { get; set; } // Identity 

        public int TotalPrice { get; set; }

    }
}
