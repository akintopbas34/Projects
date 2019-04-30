using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.Orders;
using SarfMalzemeStok.Service.Orders.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : AbpController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetOrders()
        {
            return _orderService.GetOrder();
        }

        [HttpGet("{materialId}/{companyId}")]
        public OrderDto GetOrdersByMaterial(int materialId, int companyId)
        {
            if (companyId != 0)
            {
                return _orderService.GetOrderByMaterial(materialId, companyId);
            }
            return null;
        }
    }
}