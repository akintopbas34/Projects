using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Consumptions.Dto
{
    [AutoMap(typeof(Consumption))]
    public class ConsumptionDto: EntityDto
    {
        public int MaterialId { get; set; }
        public DateTime KullanimTarihi { get; set; }
        public int TuketimMiktari { get; set; }
        public string Birim { get; set; }

        public Material material { get; set; }
    }
}
