using System.Linq.Expressions;

namespace HotelReservationApp.DataAccess.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetByID(int id);
        List<T> GetList();
        //List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
