using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        CustomerRepository repository;
        public CustomerController()
        {
            repository = new CustomerRepository();
        }
        #region GetAllItem
        [HttpGet]
        public JsonResult GetAllItems()
        {
            List<Items> itemList = null;
            try
            {
                itemList = repository.GetAllItems();
            }
            catch (Exception)
            {

                itemList = null;
            }
            return Json(itemList);
        }
        #endregion

        #region GetAllItemByCategoryName
        [HttpGet]
        public JsonResult GetAllItemByCategoryName(string categoryName)
        {
            List<ItemDetails> listIems = null;
            try
            {
                listIems = repository.GetItemDetails(categoryName);
            }
            catch (Exception)
            {

                listIems = null;
            }
            return Json(listIems);
            
        }
        #endregion

        #region GetItemPrice
        [HttpGet]
        public JsonResult GetItemPrice(string itemId)
        {

            decimal result;
            try
            {
                result = repository.GetItemPrice(itemId);
            }
            catch (Exception)
            {

                result = 0;
            }
            return Json(result);
        }
        #endregion
    }
}
