using Abp.Application.Services;
using SarfMalzemeStok.Service.HistoryInformationReports.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.HistoryInformationReports
{
    public interface IHistoryInformationReportService : IApplicationService
    {
        IEnumerable<HistoryInformationReportDto> GetHistoryInformationReportById(int materialId);
    }
}
