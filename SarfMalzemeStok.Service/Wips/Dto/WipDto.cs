using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SarfMalzemeStok.Service.Wips.Dto
{
    [AutoMap(typeof(Wip))]
    public class WipDto:EntityDto
    {
        public int MaterialId { get; set; }
        public string TezgahAdi { get; set; }

        public Material material { get; set; }
    }
}
