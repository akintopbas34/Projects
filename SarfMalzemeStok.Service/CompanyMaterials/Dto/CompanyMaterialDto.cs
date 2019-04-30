using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SarfMalzemeStok.Service.CompanyMaterials.Dto
{
    [AutoMap(typeof(CompanyMaterial))]
    public class CompanyMaterialDto : EntityDto
    {
        public int CompanyId { get; set; }
        public int MaterialId { get; set; }
        public double BirimMaliyet { get; set; }
        public int TedarikSuresi { get; set; }
        public int AsgariPartiBuyuklugu { get; set; }

        public Material material { get; set; }
        public Company company { get; set; }
    }
}
