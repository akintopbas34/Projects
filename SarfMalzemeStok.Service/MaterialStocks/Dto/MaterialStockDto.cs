using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.MaterialStocks.Dto
{
    [AutoMap(typeof(MaterialStock))]
    public class MaterialStockDto: EntityDto
    {
        public int MaterialId { get; set; }
        public double DepodakiMiktar { get; set; }
        public double AtolyedekiMiktar { get; set; }
        public double TedarikAsamasindakiMiktar { get; set; }
        public double StokMiktari { get; set; }

        public Material material { get; set; }
    }
}
