using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SarfMalzemeStok.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SarfMalzemeStok.Service.AlternativeMaterials.Dto
{
    [AutoMap(typeof(AlternativeMaterial))]
    public class AlternativeMaterialDto :EntityDto
    {
        public int Material1Id { get; set; }
        public int Material2Id { get; set; }

        [ForeignKey("Material1Id")]
        public Material material1 { get; set; }
        [ForeignKey("Material2Id")]
        public Material material2 { get; set; }
    }
}
