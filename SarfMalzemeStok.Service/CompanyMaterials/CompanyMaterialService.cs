using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SarfMalzemeStok.Domain.Context;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.CompanyMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.CompanyMaterials
{
    public class CompanyMaterialService: ApplicationService,ICompanyMaterialService
    {
        private readonly IRepository<CompanyMaterial> _companyMaterialRepository;

        public CompanyMaterialService(IRepository<CompanyMaterial> companyMaterialRepository)
        {
            _companyMaterialRepository = companyMaterialRepository;
        }

        public IEnumerable<CompanyMaterialDto> GetCompanyMaterial() => _companyMaterialRepository.GetAllIncluding(i => i.material, x => x.company).Select(x => ObjectMapper.Map<CompanyMaterialDto>(x)).ToList();
        
        public CompanyMaterialDto GetCompanyMaterialById(int materialId ,int companyId)
        {
            return _companyMaterialRepository.GetAllIncluding(x => x.material, x => x.company).Select(x => ObjectMapper.Map<CompanyMaterialDto>(x)).Where(x=>x.MaterialId == materialId && x.CompanyId == companyId).FirstOrDefault();
        }

        public IEnumerable<CompanyMaterialDto> GetCompanyMaterialByMaterial(int materialId)
        {
            return _companyMaterialRepository.GetAllIncluding(x => x.material, x => x.company).Select(x => ObjectMapper.Map<CompanyMaterialDto>(x)).Where(x => x.MaterialId == materialId).ToList();
        }


    }
}
