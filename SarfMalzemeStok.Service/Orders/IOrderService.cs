using Abp.Application.Services;
using SarfMalzemeStok.Service.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Orders
{
    public interface IOrderService : IApplicationService
    {
        IEnumerable<OrderDto> GetOrder();
        OrderDto GetOrderByMaterial(int materialId, int companyId);
    }
}
