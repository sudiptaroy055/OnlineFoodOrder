using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //GetAllItems();
            //GetAllItemByCategoryName();
            //GetItemPrice();
            //AddItem();
            GetAllCategoryOrderDetails();
        }
        #region Customer

        #region GetAllItems
        public static void GetAllItems()
        {
            CustomerRepository repository = new CustomerRepository();
            List<Items> itemList = null;
            itemList = repository.GetAllItems();
            if (itemList != null)
            {
                Console.WriteLine("List of Items are");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("ItemId \tItem Name\tCategory Id\tPrice");
                foreach (var item in itemList)
                {
                    Console.WriteLine("{0, -10}{1, -20}{2,-20}{3}", item.ItemId, item.ItemName, item.CategoryId, item.Price);
                }
                Console.WriteLine("-------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Some error occured pls check");
            }
        }
        #endregion

        #region GetAllItemByCategoryName
        public static void GetAllItemByCategoryName()
        {
            CustomerRepository repository = new CustomerRepository();
            string categoryName = "Pizza";
            List<ItemDetails> listItems = null;
            listItems = repository.GetItemDetails(categoryName);
            if (listItems!=null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Item Id\t\tItem Name\tPrice");
                foreach (var item in listItems)
                {
                    Console.WriteLine("{0, -10}{1, -20}{2}", item.ItemId, item.ItemName, item.Price);
                }
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Something went wrong, Check Category Name");
            }
        }
        #endregion

        #region GetItemPrice
        public static void GetItemPrice()
        {
            CustomerRepository repository = new CustomerRepository();
            decimal result = 0;
            string itemId = "CBR";
            result = repository.GetItemPrice(itemId);
            if (result == 0)
            {
                Console.WriteLine("Item dose not exist, check Item Id");
            }
            else
            {
                Console.WriteLine("price: " + result);
            }
        }
        #endregion

        #endregion

        #region Admin

        #region AddItem
        public static void AddItem()
        {
            AdminRepository repository = new AdminRepository();
            bool result;
            result = repository.AddItem("SBR", "Special Chicken Biryani", 120, 1);
            if (result)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("    New item addd successfull    ");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("   Somehing went wrong try again   ");
                Console.WriteLine("-------------------------------------");
            }
        }
        #endregion

        #region GetAllCategoryOrderDetails
        public static void GetAllCategoryOrderDetails()
        {
            AdminRepository repository = new AdminRepository();
            int CategoryId = 1;
            List<CategoryItemDetails> categoryItemDetails = null;
            categoryItemDetails = repository.GetAllCategoryOrderDetails(CategoryId);
            if (categoryItemDetails != null)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0, -12}{1, -12}{2, -20}{3, -20}{4, -30}{5, -25}{6}", "OrderId",
                "CustomerId", "CustomerName", "ItemName","DeliveryAddress", "OrderDate", "DeliveryStatus");
                foreach (var item in categoryItemDetails) 
                {
                    Console.WriteLine("{0, -12}{1, -12}{2, -20}{3, -20}{4, -30}{5, -25}{6}",item.OrderId, item.CustomerId, item.CustomerName,
                        item.ItemName, item.DeliveryAddress, item.OrderDate, item.DeliveryStatus);
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("No order available for this category");
                Console.WriteLine("--------------------------------------");
            }
        }
        #endregion

        #endregion
    }
}
