using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ProductAppService _productAppService;
        OrderAppService _orderAppService;
        OrderDetailsAppService _orderDetailsAppService;
        IHttpContextAccessor _httpContextAccessor;
        public OrderController(OrderAppService orderAppService,
           OrderDetailsAppService orderDetailsAppService, ProductAppService productAppService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._orderAppService = orderAppService;
            this._productAppService  = productAppService; 
            this._orderDetailsAppService = orderDetailsAppService ;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public ActionResult GetAllOrders()
        {
            return Ok(_orderAppService.GetAllOrder());
        }


        public IActionResult makeOrder(OrderDetailsViewModel ordeDetailsrViewModel)//, double totalOrderPrice)
        {

            //get cart id of current logged user

            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            OrderViewModel orderViewModel = new OrderViewModel
            {
                Orderdate = DateTime.Now.ToString(),

            
                ApplicationUserIdentity_Id = userID

            };
            _orderAppService.SaveNewOrder(orderViewModel);
            var lastOrder = _orderAppService.GetAllOrder().Select(o => o.OrderId).LastOrDefault();

            //get know details of each product
            

            return Ok();
        }



        //[HttpGet]
        //Route[("api/[controller]/{id}")]
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {

            var orderProductViewModels = _orderDetailsAppService.GetAllOrderDetails().Where(op => op.orderID == id).ToList();
            //foreach (var item in orderProductViewModels)
            //{
            //    item.productName = _productAppService.GetProduct(item.ProductID).Name;
            //}

            return Ok(_orderDetailsAppService.GetAllOrderDetails().Where(op => op.orderID == id).ToList());
            //return Ok(orderProductViewModels);
        }
        [HttpGet("count")]
        public IActionResult OrderCount()
        {
            return Ok(_orderAppService.CountEntity());
        }
        [HttpGet("countOrdersForSpecifcUser/{userID}")]
        public IActionResult OrderCount(string userID)
        {
            return Ok(_orderAppService.CountEntityForSpecficUser(userID));
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetOrdersByPage(int pageSize, int pageNumber)
        {
            var list = _orderAppService.GetPageRecords(pageSize, pageNumber);
            return Ok(_orderAppService.GetPageRecords(pageSize, pageNumber));
        }
        [HttpGet("{userID}/{pageSize}/{pageNumber}")]
        public IActionResult GetOrdersByPageForSpecficUser(string userID, int pageSize, int pageNumber)
        {

            return Ok(_orderAppService.GetPageRecordsForSpeceficUser(userID, pageSize, pageNumber));
        }
    }
} 