using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurants.Models;

namespace WebAppRestaurants.Repositories
{
    public class ItemRepository
    {

        private RestaurentDBEntities objrestaurentDBEntities;
        public ItemRepository()
        {
            objrestaurentDBEntities = new RestaurentDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {


            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurentDBEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.  ItemId.ToString(),
                                      Selected = false
                                  }).ToList();
            return objSelectListItems;


        }
    }
}