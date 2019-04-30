using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.ProductGroupConsumptionReports.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.ProductGroupConsumptionReports
{
    public class ProductGroupConsumptionReportService : ApplicationService, IProductGroupConsumptionReportService
    {
        private readonly IRepository<ProductGroupConsumptionReport> _productionGroupConsumptionReportRepository;

        public ProductGroupConsumptionReportService(IRepository<ProductGroupConsumptionReport> productionGroupConsumptionReportRepository)
        {
            _productionGroupConsumptionReportRepository = productionGroupConsumptionReportRepository;
        }

        public IEnumerable<ProductGroupConsumptionReportDto> GetProductGroupConsumptionReportById(int materialId)
        {
            return _productionGroupConsumptionReportRepository.GetAllIncluding(i => i.material).Select(x => ObjectMapper.Map<ProductGroupConsumptionReportDto>(x)).Where(x => x.MaterialId == materialId).ToList();
        }
    }
}
