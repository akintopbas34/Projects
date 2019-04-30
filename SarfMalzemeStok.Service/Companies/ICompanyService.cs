using Abp.Application.Services;
using SarfMalzemeStok.Service.Companies.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Companies
{
    public interface ICompanyService: IApplicationService
    {
        IEnumerable<CompanyDto> GetCompany();
    }
}
