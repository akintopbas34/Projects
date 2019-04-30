using Abp.Application.Services;
using SarfMalzemeStok.Service.BenchStandbyReports.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.BenchStandbyReports
{
    public interface IBenchStandbyReportService : IApplicationService
    {
        IEnumerable<BenchStandbyReportDto> GetBenchStandbyReportById(int materialId);
    }
}
