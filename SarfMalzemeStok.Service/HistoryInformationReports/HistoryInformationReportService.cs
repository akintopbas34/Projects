using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.HistoryInformationReports.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.HistoryInformationReports
{
    public class HistoryInformationReportService : ApplicationService, IHistoryInformationReportService
    {
        private readonly IRepository<HistoryInformationReport> _historyInformationReportRepository;

        public HistoryInformationReportService(IRepository<HistoryInformationReport> historyInformationReportRepository)
        {
            _historyInformationReportRepository = historyInformationReportRepository;
        }

        public IEnumerable<HistoryInformationReportDto> GetHistoryInformationReportById(int materialId)
        {
            return _historyInformationReportRepository.GetAllIncluding(i => i.material).Select(x => ObjectMapper.Map<HistoryInformationReportDto>(x)).Where(x => x.MaterialId == materialId).ToList();
        }
    }
}
