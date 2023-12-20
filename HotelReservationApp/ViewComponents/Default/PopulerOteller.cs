using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.ViewComponents.Default
{
    public class PopulerOteller : ViewComponent
    {
        //PopulerOtellerManager populerOtellerManager = new PopulerOtellerManager(new EfPopulerOtellerDal());
        public IViewComponentResult Invoke()
        {

            //var values = populerOtellerManager.TGetList();
            //using var c = new Context();



            return View();

        }
    }
}
