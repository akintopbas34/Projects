using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarfMalzemeStok.Service.Companies;
using SarfMalzemeStok.Service.Companies.Dto;
using SarfMalzemeStok.Service.CompanyMaterials.Dto;
using SarfMalzemeStok.Service.Materials;

namespace SarfMalzemeStok.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CompanyController : AbpController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IEnumerable<CompanyDto> GetCompanies()
        {
            return _companyService.GetCompany();
        }
    }
}