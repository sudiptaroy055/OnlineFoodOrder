using DataAccessLayer;
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
    public class CommonController : Controller
    {
        CommonRepository repository;
        public CommonController()
        {
            repository = new CommonRepository();
        }

        #region CheckDeliveryStatus
        [HttpGet]
        public JsonResult CheckDeliveryStatus(int OrderId)
        {
            int status;
            string message;
            status = repository.CheckDeliveryStatus(OrderId);
            try
            {
                if (status == 1)
                {
                    message = "Order not Delivered !";
                }
                else if (status == 0)
                {
                    message = "Delivered !";
                }
                else
                {
                    message = "Invalid Order !";
                }
            }
            catch (Exception)
            {

                message = "An error occured";
            }
            return Json(message);
        }
        #endregion

        #region DeleteOrderDetails
        public JsonResult DeleteOrderDetails(int OrderId)
        {
            bool status;
            string message;
            status = repository.DeleteOrderDetails(OrderId);
            try
            {
                if (status)
                {
                    message = "Order cancled !";
                }
                else
                {
                    message = "Try again";
                }
            }
            catch (Exception)
            {

                message = "An error occured";
            }
            return Json(message);
        }
        #endregion

    }
}
