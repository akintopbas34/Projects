using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Companies.Dto
{
    [AutoMap(typeof(Company))]
    public class CompanyDto : EntityDto
    {
        public string FirmaKodu { get; set; }
        public string FirmaAdi { get; set; }
    }
}
