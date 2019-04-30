using Abp.Application.Services;
using SarfMalzemeStok.Service.CompanyMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.CompanyMaterials
{
    public interface ICompanyMaterialService : IApplicationService
    {
        IEnumerable<CompanyMaterialDto> GetCompanyMaterial();
        CompanyMaterialDto GetCompanyMaterialById(int materialId,int companyId);
        IEnumerable<CompanyMaterialDto> GetCompanyMaterialByMaterial(int materialId);
    }
}
