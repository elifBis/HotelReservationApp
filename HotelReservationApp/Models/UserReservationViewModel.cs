namespace HotelReservationApp.Models
{
    public class UserReservationViewModel
    {
        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomTypeId { get; set; }
        public string HotelName { get; set; }
        public int TotalPrice { get; set; }
    }
}
