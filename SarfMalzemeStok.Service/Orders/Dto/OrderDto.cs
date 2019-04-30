using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Orders.Dto
{
    [AutoMap(typeof(Order))]
    public class OrderDto:EntityDto
    {
        public int CompanyMaterialId { get; set; }
        public DateTime SiparisVerilmeZamani { get; set; }
        public bool SiparisinGerceklesmeDurumu { get; set; }
        public DateTime SiparisTamamlanmaZamani { get; set; }
        public double SiparisVermeMaliyeti { get; set; }

        public CompanyMaterial companyMaterial { get; set; }
    }
}
