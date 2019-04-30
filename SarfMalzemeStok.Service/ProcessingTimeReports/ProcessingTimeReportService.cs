using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.ProcessingTimeReports.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.ProcessingTimeReports
{
    public class ProcessingTimeReportService : ApplicationService, IProcessingTimeReportService
    {
        private readonly IRepository<ProcessingTimeReport> _processingTimeReportRepository;

        public ProcessingTimeReportService(IRepository<ProcessingTimeReport> processingTimeReportRepository)
        {
            _processingTimeReportRepository = processingTimeReportRepository;
        }

        public IEnumerable<ProcessingTimeReportDto> GetProcessingTimeReportById(int materialId)
        {
            return _processingTimeReportRepository.GetAllIncluding(i => i.material).Select(x => ObjectMapper.Map<ProcessingTimeReportDto>(x)).Where(x => x.MaterialId == materialId).ToList();
        }
    }
}
