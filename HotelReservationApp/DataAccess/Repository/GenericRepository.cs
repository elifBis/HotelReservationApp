using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HotelReservationApp.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly MyDbContext _context;
        public GenericRepository(DbContextOptions<MyDbContext> dbContextOptions)
        {
            _context = new MyDbContext(dbContextOptions);
        }
        public void Delete(T t)
        {
            // using var c = new MyDbContext();
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            //using var c = new MyDbContext();
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
           // using var c = new MyDbContext();
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            //using var c = new MyDbContext();
            _context.Add(t);
        }

        public void Update(T t)
        {
            //using var c = new MyDbContext();
            _context.Update(t);
        }
    }
}
