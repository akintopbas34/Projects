using Abp.Application.Services;
using SarfMalzemeStok.Service.ProcessingTimeReports.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.ProcessingTimeReports
{
    public interface IProcessingTimeReportService : IApplicationService
    {
        IEnumerable<ProcessingTimeReportDto> GetProcessingTimeReportById(int materialId);
    }
}
