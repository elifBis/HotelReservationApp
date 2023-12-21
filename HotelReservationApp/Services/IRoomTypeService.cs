using HotelReservationApp.Models;

namespace HotelReservationApp.Services
{
    public interface IRoomTypeService:IGenericService<RoomType>
    {
        List<RoomType> GetAllRoomTypes();
        RoomType GetRoomTypeById(int roomTypeId);
        Hotel GetHotelByRoomId(int roomId);
    }
}
