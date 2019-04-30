using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.BenchStandbyReports.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.BenchStandbyReports
{
    public class BenchStandbyReportService : ApplicationService, IBenchStandbyReportService
    {
        private readonly IRepository<BenchStandbyReport> _benchStandbyReportRepository;
        public BenchStandbyReportService(IRepository<BenchStandbyReport> benchStandbyReportRepository)
        {
            _benchStandbyReportRepository = benchStandbyReportRepository;
        }

        public IEnumerable<BenchStandbyReportDto> GetBenchStandbyReportById(int materialId)
        {
            return _benchStandbyReportRepository.GetAllIncluding(i => i.material).Select(x => ObjectMapper.Map<BenchStandbyReportDto>(x)).Where(x => x.MaterialId == materialId).ToList();
        }
    }
}
