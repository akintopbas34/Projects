using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.RefusalInformations.Dto
{
    [AutoMap(typeof(RefusalInformation))]
    public class RefusalInformationDto:EntityDto
    {
        public int OrderId { get; set; }
        public string IadeNedeni { get; set; }
        public DateTime IadeTarihi { get; set; }
        public int IadeMiktari { get; set; }

        public Order order { get; set; }
    }
}
