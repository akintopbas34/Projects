using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.CompanyMaterials;
using SarfMalzemeStok.Service.CompanyMaterials.Dto;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CompanyMaterialController : AbpController
    {
        private readonly ICompanyMaterialService _companyMaterialService;
        public CompanyMaterialController(ICompanyMaterialService companyMaterialService)
        {
            _companyMaterialService = companyMaterialService;
        }

        [HttpGet]
        public IEnumerable<CompanyMaterialDto> GetCompanyMaterials()
        {
            return _companyMaterialService.GetCompanyMaterial();
        }

        [HttpGet("{materialId}")]
        public IEnumerable<CompanyMaterialDto> GetCompanyMaterialsByMaterial(int materialId)
        {
            return _companyMaterialService.GetCompanyMaterialByMaterial(materialId);
        }

        [HttpGet("{materialId}/{companyId}")]
        public CompanyMaterialDto GetCompanyMaterialById(int materialId, int companyId)
        {
            return _companyMaterialService.GetCompanyMaterialById(materialId, companyId);
        }
    }
}