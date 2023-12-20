namespace HotelReservationApp.Models
{

    public class Hotel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public int CityId { get; set; }
            public City City { get; set; }


            // Navigation property for RoomTypes
            public List<RoomType> RoomTypes { get; set; }
        

    }
}
