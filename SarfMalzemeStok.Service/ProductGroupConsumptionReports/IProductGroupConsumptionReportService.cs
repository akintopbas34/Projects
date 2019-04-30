using Abp.Application.Services;
using SarfMalzemeStok.Service.ProductGroupConsumptionReports.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.ProductGroupConsumptionReports
{
    public interface IProductGroupConsumptionReportService : IApplicationService
    {
        IEnumerable<ProductGroupConsumptionReportDto> GetProductGroupConsumptionReportById(int materialId);
    }
}
