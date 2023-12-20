namespace HotelReservationApp.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Category { get; set; }
        public int PricePerNight { get; set; }

        // Navigation property for Hotel
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
