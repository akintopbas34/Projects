using Abp.Application.Services;
using Abp.Domain.Repositories;
using SarfMalzemeStok.Domain.Model;
using SarfMalzemeStok.Service.Companies.Dto;
using SarfMalzemeStok.Service.Materials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SarfMalzemeStok.Service.Companies
{
    public class CompanyService : ApplicationService, ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IEnumerable<CompanyDto> GetCompany() => _companyRepository.GetAll().Select(x => ObjectMapper.Map<CompanyDto>(x)).ToList();
    }
}
