using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurants.Models;
using WebAppRestaurants.Repositories;
using WebAppRestaurants.ViewModel;

namespace WebAppRestaurants.Controllers
{
    public class HomeController : Controller
    {
        private RestaurentDBEntities objrestaurentDBEntities;
        public HomeController()
        {
            objrestaurentDBEntities = new RestaurentDBEntities();
        }
        public ActionResult Index()
        {
            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItemRepository objitemRepository = new ItemRepository();
            PaymentTypeRepository objpaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objcustomerRepository.GetAllCustomer(), objitemRepository.GetAllItems(), objpaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = (decimal)objrestaurentDBEntities.Items.Single(Model => Model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice,JsonRequestBehavior.AllowGet);


        } [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);

            return Json(data: "your order has beed sucessfully placed", JsonRequestBehavior.AllowGet);
        }


       // public ActionRes
       //     ult About()
       // {
          //  ViewBag.Message = "Your application description page.";

         //   return View();
       // }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}