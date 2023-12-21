using HotelReservationApp.Models;

namespace HotelReservationApp.Services
{
    public interface IHotelService:IGenericService<Hotel>
    {
        public List<HotelViewModel> GetAllHotels();
        public Hotel GetHotelById(int id);
        public List<RoomType> GetRoomTypesByHotelId(int hotelId);


    }
}
