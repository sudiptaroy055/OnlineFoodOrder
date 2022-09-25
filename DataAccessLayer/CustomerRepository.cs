using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class CustomerRepository
    {
        OnlineFoodOrderDBContext context;
        public CustomerRepository()
        {
            context = new OnlineFoodOrderDBContext();
        }

        #region GetAllItems
        public List<Items> GetAllItems()
        {
            List<Items> lstItems = null;
            try
            {
                lstItems = context.Items.ToList();
            }
            catch (Exception)
            {

                lstItems = null;
            }
            return lstItems;
        }

        #endregion

        #region GetItemDetails
        public List<ItemDetails> GetItemDetails(string categoryName)
        {
            List<ItemDetails> itemDetailsList = null;
            try
            {
                SqlParameter prmCatrgoryName = new SqlParameter("@CategoryName", categoryName);
                itemDetailsList = context.ItemDetails.FromSqlRaw("SELECT * FROM ufn_FetchItemDetails(@CategoryName)",
                    prmCatrgoryName).ToList();
            }
            catch (Exception)
            {

                itemDetailsList = null;   
            }
            return itemDetailsList;
        }
        #endregion

        #region GetItemPrice
        public decimal GetItemPrice(string itemId)
        {
            decimal result;
            try
            {
                result = (from item in context.Items  select OnlineFoodOrderDBContext.GetItemPrice(itemId)).FirstOrDefault();
            }
            catch (Exception)
            {
                result = 0;                
            }
            return result;
        }
        #endregion
    }
}
