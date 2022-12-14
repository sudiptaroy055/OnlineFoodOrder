using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace WebServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        AdminRepository repository;
        public AdminController()
        {
            repository = new AdminRepository();
        }

        #region AddItem
        [HttpPost]
        public JsonResult AddItem(Models.Item item)
        {
            bool status = false;
            string message = null;

            try
            {
                Items itemObj = new Items();
                itemObj.ItemId = item.ItemId;
                itemObj.ItemName = item.ItemName;
                itemObj.Price = item.Price;
                itemObj.CategoryId = item.CategoryId;

                status = repository.AddItem(itemObj.ItemId, itemObj.ItemName, itemObj.Price, itemObj.CategoryId);
                if (status)
                {
                    message = "Item added successfully";
                }
                else
                {
                    message = "Unsuccessful addition operation";
                }
            }
            catch (Exception)
            {
                status = false;
                message = "Some error occured, please try again";
            }
            return Json(message);
        }
        #endregion

        #region GetAllCategoryOrderDetails
        [HttpGet]
        public JsonResult GetAllCategoryOrderDetails(int categoryId)
        {
            List<CategoryItemDetails> itemDetails = new List<CategoryItemDetails>();
            try
            {
                itemDetails = repository.GetAllCategoryOrderDetails(categoryId).ToList();
            }
            catch (Exception)
            {
                itemDetails = null;
            }
            return Json(itemDetails);
        }
        #endregion

        #region UpdatePrice 
        [HttpPut]
        public JsonResult UpdatePrice(string ItemId, decimal ItemPrice)
        {
            bool status;
            string message;
            try
            {
                status = repository.UpdatePrice(ItemId, ItemPrice);
                if (status)
                {
                    message = "Price updated successfully";
                }
                else
                {
                    message = "Unseccessful update operation try again";
                }
            }
            catch (Exception)
            {
                message = "Something went wrong try again!!!";
            }
            return Json(message);
        }
        #endregion
    }
}
