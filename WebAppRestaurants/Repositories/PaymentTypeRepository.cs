using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using WebAppRestaurants.Models;

namespace WebAppRestaurants.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurentDBEntities objrestaurentDBEntities;
        public PaymentTypeRepository()
        {
            objrestaurentDBEntities = new RestaurentDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
          

            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurentDBEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;


        }





    }
}