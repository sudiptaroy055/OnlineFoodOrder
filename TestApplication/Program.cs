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
        }
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
    }
}
