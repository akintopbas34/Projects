using Abp.Application.Services;
using SarfMalzemeStok.Service.ProductInformations.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.ProductInformations
{
    public interface IProductInformationService : IApplicationService
    {
        IEnumerable<ProductInformationDto> GetProductInformation();
        ProductInformationDto GetProductInformationByMaterial(int materialId);
    }
}
