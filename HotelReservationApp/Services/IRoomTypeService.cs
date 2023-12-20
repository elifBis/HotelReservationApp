using HotelReservationApp.Models;

namespace HotelReservationApp.Services
{
    public interface IRoomTypeService
    {
        List<RoomType> GetAllRoomTypes();
        RoomType GetRoomTypeById(int roomTypeId);
    }
}
