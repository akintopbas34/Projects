using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SarfMalzemeStok.Domain.Model
{
    public class CompanyMaterial:Entity
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
