using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Context;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.Orders
{
    public class OrderService : ApplicationService, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetOrder()
        {
            return _orderRepository
                .GetAllIncluding(x => x.companyMaterial)
                .Select(x => ObjectMapper.Map<OrderDto>(x))
                .ToList();
        }

        public OrderDto GetOrderByMaterial(int materialId, int companyId)
        {
            IEnumerable<OrderDto> order = _orderRepository
                .GetAllIncluding(x => x.companyMaterial, i=>i.companyMaterial.material,y=>y.companyMaterial.company)
                .Select(x => ObjectMapper.Map<OrderDto>(x))
                .AsQueryable();
            //var asdas = order.ElementAt(0).companyMaterial.MaterialId;
            OrderDto order1 = order
                .Where(x => x.companyMaterial.MaterialId == materialId && x.companyMaterial.CompanyId == companyId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return order1;
            //return _orderRepository
            //    .GetAllIncluding(x => x.companyMaterial)
            //    .Select(x => ObjectMapper.Map<OrderDto>(x))
            //    .Where(x => x.companyMaterial.MaterialId == materialId && x.companyMaterial.CompanyId == companyId)
            //    .ToList();
        }
    }
}
