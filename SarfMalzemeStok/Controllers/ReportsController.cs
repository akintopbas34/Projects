using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.BenchStandbyReports;
using SarfMalzemeStok.Service.BenchStandbyReports.Dto;
using SarfMalzemeStok.Service.HistoryInformationReports;
using SarfMalzemeStok.Service.HistoryInformationReports.Dto;
using SarfMalzemeStok.Service.ProcessingTimeReports;
using SarfMalzemeStok.Service.ProcessingTimeReports.Dto;
using SarfMalzemeStok.Service.ProductGroupConsumptionReports;
using SarfMalzemeStok.Service.ProductGroupConsumptionReports.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ReportsController : AbpController
    {
        private readonly IHistoryInformationReportService _historyInformationReportService;
        private readonly IProcessingTimeReportService _processingTimeReportService;
        private readonly IProductGroupConsumptionReportService _productGroupConsumptionReport;
        private readonly IBenchStandbyReportService _benchStandbyReportService;

        public ReportsController(IHistoryInformationReportService historyInformationReportService,
                                 IProcessingTimeReportService processingTimeReportService,
                                 IProductGroupConsumptionReportService productGroupConsumptionReportService,
                                 IBenchStandbyReportService benchStandbyReportService)
        {
            _historyInformationReportService = historyInformationReportService;
            _processingTimeReportService = processingTimeReportService;
            _productGroupConsumptionReport = productGroupConsumptionReportService;
            _benchStandbyReportService = benchStandbyReportService;
        }

        [HttpGet("{materialId}")]
        public IEnumerable<HistoryInformationReportDto> GetHistoryInformationReportsByMaterial(int materialId)
        {
            return _historyInformationReportService.GetHistoryInformationReportById(materialId);
        }

        [HttpGet("{materialId}")]
        public IEnumerable<ProductGroupConsumptionReportDto> GetProductGroupConsumptionReportsByMaterial(int materialId)
        {
            return _productGroupConsumptionReport.GetProductGroupConsumptionReportById(materialId);
        }

        [HttpGet("{materialId}")]
        public IEnumerable<ProcessingTimeReportDto> GetProcessingTimeReportsByMaterial(int materialId)
        {
            return _processingTimeReportService.GetProcessingTimeReportById(materialId);
        }

        [HttpGet("{materialId}")]
        public IEnumerable<BenchStandbyReportDto> GetBenchStandbyReportsByMaterial(int materialId)
        {
            return _benchStandbyReportService.GetBenchStandbyReportById(materialId);
        }
    }
}