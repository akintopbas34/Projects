using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class AlternativeMaterial : Entity
    {
        public int? Material1Id { get; set; }

        [ForeignKey("Material1Id")]
        public Material material1 { get; set; }

        public int? Material2Id { get; set; }

        [ForeignKey("Material2Id")]
        public Material material2 { get; set; }

    }
}
