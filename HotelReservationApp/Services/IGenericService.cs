namespace HotelReservationApp.Services
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        T TGetByID(int id);
        List<T> TGetList();
       // List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
