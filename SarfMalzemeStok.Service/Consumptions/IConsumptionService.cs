using Abp.Application.Services;
using SarfMalzemeStok.Service.Consumptions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Consumptions
{
    public interface IConsumptionService : IApplicationService
    {
        IEnumerable<ConsumptionDto> GetConsumptionByYear(int materialId,int year);
        IEnumerable<ConsumptionDto> GetCurrentConsumptionYear(int materialId,int year);
    }
}
