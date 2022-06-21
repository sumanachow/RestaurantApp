using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurants.Models;

namespace WebAppRestaurants.Repositories
{
    public class CustomerRepository
    {

        private RestaurentDBEntities objrestaurentDBEntities;
        public CustomerRepository()
        {
            objrestaurentDBEntities = new RestaurentDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomer()
        {


            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurentDBEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;


        }
    }
}