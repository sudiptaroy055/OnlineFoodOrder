using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class AdminRepository
    {
        OnlineFoodOrderDBContext context;

        public AdminRepository()
        {
            context = new OnlineFoodOrderDBContext();
        }

        #region AddItem
        public bool AddItem(string itemId, string itemName, decimal price, int categoryId)
        {
            bool status = false;
            Items item = new Items();
            item.ItemId = itemId;
            item.ItemName = itemName;
            item.CategoryId = categoryId;
            item.Price = price;
            try
            {
                context.Items.Add(item);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region GetAllCategoryOrderDetails
        public List<CategoryItemDetails> GetAllCategoryOrderDetails(int categoryId)
        {
            List<CategoryItemDetails> lstProduct = null;
            try
            {
                SqlParameter prmCategoryId = new SqlParameter("@CategoryId", categoryId);
                lstProduct = context.CategoryItemDetails.FromSqlRaw("SELECT * FROM ufn_GetAllOrderDetails(@CategoryId)", prmCategoryId).ToList();
            }
            catch (Exception)
            {
                lstProduct = null;
            }
            return lstProduct;
        }
        #endregion
    }
}
