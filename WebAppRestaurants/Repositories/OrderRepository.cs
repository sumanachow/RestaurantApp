using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppRestaurants.Models;
using WebAppRestaurants.ViewModel;

namespace WebAppRestaurants.Repositories
{
    public class OrderRepository
    {
        private RestaurentDBEntities objrestaurentDBEntities;
        public OrderRepository()
        {
            objrestaurentDBEntities = new RestaurentDBEntities();
        }
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objorder = new Order();
            objorder.CustomerId = objOrderViewModel.CustomerId;
            objorder.FinalTotal = objOrderViewModel.FinalTotal;
            objorder.OrderDate = DateTime.Now;
            objorder.OrderNumber = String.Format("{0:ddmmyyyhhmmss}", DateTime.Now);
            objorder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objrestaurentDBEntities.Orders.Add(objorder);
            objrestaurentDBEntities.SaveChanges();
            int OrderId = objorder.OrderId;

            foreach(var item in objOrderViewModel.ListoforderDetailsViewModels)
            { 
                OrderDetail objOrderDetails = new OrderDetail();
                objOrderDetails.OrderId = OrderId;
                objOrderDetails.Discount = item.Discount;
                objOrderDetails.ItemId = item.ItemId;
                objOrderDetails.Total = item.Total;
                objOrderDetails.UnitPrice = item.UnitPrice;
                objOrderDetails.Quantity = item.Quantity;
                objrestaurentDBEntities.OrderDetails.Add(objOrderDetails);
                objrestaurentDBEntities.SaveChanges();

                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = item.ItemId;
               // objTransaction.Quantity = (-1) * item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;
                objrestaurentDBEntities.Transactions.Add(objTransaction);
                objrestaurentDBEntities.SaveChanges();



            }


            return true;
        }
    }
    }
 