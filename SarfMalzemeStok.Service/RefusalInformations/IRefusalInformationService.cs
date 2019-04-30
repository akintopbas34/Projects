using Abp.Application.Services;
using SarfMalzemeStok.Service.RefusalInformations.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.RefusalInformations
{
    public interface IRefusalInformationService:IApplicationService
    {
        IEnumerable<RefusalInformationDto> GetRefusalInformation();
        RefusalInformationDto GetRefusalInformationByOrder(int orderId);
    }
}
