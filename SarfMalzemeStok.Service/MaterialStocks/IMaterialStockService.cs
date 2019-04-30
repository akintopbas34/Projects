using Abp.Application.Services;
using SarfMalzemeStok.Service.MaterialStocks.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.MaterialStocks
{
    public interface IMaterialStockService : IApplicationService
    {
        IEnumerable<MaterialStockDto> GetMaterialStock();
        MaterialStockDto GetMaterialStockByMaterial(int materialId);
    }
}
