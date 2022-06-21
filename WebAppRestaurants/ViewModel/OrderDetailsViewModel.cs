﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppRestaurants.ViewModel
{
    public class OrderDetailsViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}