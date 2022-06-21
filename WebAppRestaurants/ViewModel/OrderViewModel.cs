using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppRestaurants.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal FinalTotal { get; set; }
        public IEnumerable<OrderDetailsViewModel> ListoforderDetailsViewModels { get; set;}
    }
}