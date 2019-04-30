using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.Consumptions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.Consumptions
{
    public class ConsumptionService : ApplicationService, IConsumptionService
    {
        private readonly IRepository<Consumption> _consumptionRepository;

        public ConsumptionService(IRepository<Consumption> consumptionRepository)
        {
            _consumptionRepository = consumptionRepository;
        }
      
        public IEnumerable<ConsumptionDto> GetConsumptionByYear(int materialId,int year)
        {
            return _consumptionRepository.GetAllIncluding(x => x.material).Select(x => ObjectMapper.Map<ConsumptionDto>(x)).Where(x => x.MaterialId == materialId && x.KullanimTarihi.Year == year).ToList();
        }
        
        public IEnumerable<ConsumptionDto> GetCurrentConsumptionYear(int materialId,int year)
        {
            return _consumptionRepository.GetAllIncluding(x => x.material).Select(x => ObjectMapper.Map<ConsumptionDto>(x)).Where(x => x.MaterialId == materialId && x.KullanimTarihi.Year == year).ToList();
        }
    }
}
