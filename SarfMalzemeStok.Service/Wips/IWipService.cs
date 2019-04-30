using Abp.Application.Services;
using SarfMalzemeStok.Service.Wips.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Wips
{
    public interface IWipService : IApplicationService
    {
        IEnumerable<WipDto> GetWip();
        WipDto GetWipByMaterial(int materialId);
    }
}
