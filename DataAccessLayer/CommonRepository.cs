using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer
{
    public class CommonRepository
    {
        OnlineFoodOrderDBContext context;
        public CommonRepository()
        {
            context = new OnlineFoodOrderDBContext();
        }

        #region CheckDeliveryStatus
        public int CheckDeliveryStatus(int orderId)
        {
            int status = 0;
            try
            {
                status = (from order in context.Orders select OnlineFoodOrderDBContext.CheckDeliveryStatus(orderId))
                    .FirstOrDefault();
            }
            catch (Exception)
            {

                status = -99;
            }
            return status;
        }
        #endregion

        #region DeleteOrderDetails
        public bool DeleteOrderDetails(int OrderId)
        {
            Orders orders = null;
            bool status;

            try
            {
                orders = context.Orders.Find(OrderId);
                if (orders != null)
                {
                    context.Orders.Remove(orders);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }
        #endregion

    }
}
